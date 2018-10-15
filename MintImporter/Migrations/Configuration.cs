namespace MintImporter.Migrations
{
    using System.Data.Entity.Migrations;
    using MintImporter.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MintImporterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MintImporterDbContext context)
        {
            
        }
    }
}
