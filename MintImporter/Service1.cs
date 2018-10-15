using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using MintImporter.Models;
using Newtonsoft.Json;

namespace MintImporter
{
    public partial class Service1 : ServiceBase
    {
        private readonly FileSystemWatcher Watcher;

        public Service1()
        {
            InitializeComponent();
            Watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["TargetDirectory"], "mint_scrape_*.json");
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.Changed += new FileSystemEventHandler(OnFileChanged);
        }

        public void Test()
        {
            OnStart(new string[] { });
            Console.ReadLine();
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            foreach(var filePath in Directory.GetFiles(ConfigurationManager.AppSettings["TargetDirectory"], "mint_scrape_*.json"))
            {
                ProcessFile(filePath);
            }
            Watcher.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            Watcher.EnableRaisingEvents = false;
            Watcher.Dispose();
        }

        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            ProcessFile(e.FullPath);
        }

        private void ProcessFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var timeStampMs = Convert.ToInt64(new Regex(@"^mint_scrape_(\d*).json$").Match(fileInfo.Name).Groups[1].Value);
            var date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(timeStampMs);
            var json = File.ReadAllText(filePath);
            var accountSnapshots = JsonConvert.DeserializeObject<AccountDetails[]>(json);
            var db = new MintImporterDbContext();
            var accounts = db.Accounts.ToList();
            foreach (var accountDetail in accountSnapshots)
            {
                var account = accounts.FirstOrDefault(a => a.AccountNumber == accountDetail.accountId)
                    ?? db.Accounts.Add(new Account
                    {
                        AccountNumber = accountDetail.accountId,
                        AccountSnapshots = new List<AccountSnapshot>()
                    });
                account.AccountName = accountDetail.accountName;
                account.AccountSnapshots.Add(new AccountSnapshot
                {
                    DateTime = date,
                    Balance = accountDetail.accountBalance
                });
            }
            db.SaveChanges();
            File.Delete(filePath);
        }
    }
}
