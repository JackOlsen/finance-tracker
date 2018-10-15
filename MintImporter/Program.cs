using System.ServiceProcess;

namespace MintImporter
{
    static class Program
    {
        static void Main()
        {
            ServiceBase.Run(new[]
            {
                new Service1()
            });
            //new Service1().Test();
        }
    }
}
