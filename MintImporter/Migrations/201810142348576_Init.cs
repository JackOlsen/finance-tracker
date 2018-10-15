namespace MintImporter.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .Index(t => t.AccountNumber, unique: true);
            
            CreateTable(
                "dbo.AccountSnapshots",
                c => new
                    {
                        AccountSnapshotId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Account_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountSnapshotId)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Account_AccountId);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountSnapshots", "Account_AccountId", "dbo.Accounts");
            DropIndex("dbo.AccountSnapshots", new[] { "Account_AccountId" });
            DropIndex("dbo.Accounts", new[] { "AccountNumber" });
            DropTable("dbo.AccountSnapshots");
            DropTable("dbo.Accounts");
        }
    }
}
