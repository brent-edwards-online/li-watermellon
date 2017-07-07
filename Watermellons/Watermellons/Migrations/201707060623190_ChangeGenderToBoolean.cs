namespace Watermellons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenderToBoolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompetitionEntries", "Gender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompetitionEntries", "Gender", c => c.String(nullable: false, maxLength: 1));
        }
    }
}
