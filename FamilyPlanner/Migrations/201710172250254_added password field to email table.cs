namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpasswordfieldtoemailtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SendEmails", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SendEmails", "Password");
        }
    }
}
