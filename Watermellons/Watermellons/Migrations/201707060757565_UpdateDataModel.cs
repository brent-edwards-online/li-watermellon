namespace Watermellons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompetitionEntries", "FavouriteWatermellonPlace", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompetitionEntries", "FavouriteWatermellonPlace", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
