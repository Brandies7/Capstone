namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsendemail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SendEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SendEmails", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SendEmails", new[] { "User_Id" });
            DropTable("dbo.SendEmails");
        }
    }
}
