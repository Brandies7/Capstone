namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpasswordfromemailtable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SendEmails", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SendEmails", "Password", c => c.String(nullable: false));
        }
    }
}
