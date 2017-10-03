namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredeventstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "location", c => c.String());
            AddColumn("dbo.Events", "lat", c => c.Single(nullable: false));
            AddColumn("dbo.Events", "lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "lng");
            DropColumn("dbo.Events", "lat");
            DropColumn("dbo.Events", "location");
        }
    }
}
