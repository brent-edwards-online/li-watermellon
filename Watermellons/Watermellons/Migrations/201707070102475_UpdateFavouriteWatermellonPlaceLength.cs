namespace Watermellons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFavouriteWatermellonPlaceLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompetitionEntries", "FavouriteWatermellonPlace", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompetitionEntries", "FavouriteWatermellonPlace", c => c.String(maxLength: 100));
        }
    }
}
