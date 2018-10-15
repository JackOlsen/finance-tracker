using System.Data.Entity;

namespace MintImporter.Models
{
    public class MintImporterDbContext : DbContext
    {
        public MintImporterDbContext()
            : base("DefaultConnection") { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountSnapshot> AccountSnapshots { get; set; }
    }
}
