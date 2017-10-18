namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(nullable: false),
                        Receiver = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropTable("dbo.Messages");
        }
    }
}
