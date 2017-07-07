namespace Watermellons.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToEmailColumn : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CompetitionEntries", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompetitionEntries", new[] { "Email" });
        }
    }
}
