namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtotheeventstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "event_location", c => c.String());
            AddColumn("dbo.Events", "textColor", c => c.String());
            DropColumn("dbo.Events", "start_time");
            DropColumn("dbo.Events", "end_time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "end_time", c => c.String());
            AddColumn("dbo.Events", "start_time", c => c.String());
            DropColumn("dbo.Events", "textColor");
            DropColumn("dbo.Events", "event_location");
        }
    }
}
