namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedassignedtotochorestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chores", "AssignedTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chores", "AssignedTo");
        }
    }
}
