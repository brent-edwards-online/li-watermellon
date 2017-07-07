namespace Watermellons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompetitionEntries",
                c => new
                    {
                        CompetitionEntryId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 1),
                        FavouriteWatermellonPlace = c.String(nullable: false, maxLength: 100),
                        TermsAndConditionsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionEntryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompetitionEntries");
        }
    }
}
