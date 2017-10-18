namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inbox : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        NewMessage = c.String(),
                        messsage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.messsage_Id)
                .Index(t => t.messsage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inboxes", "messsage_Id", "dbo.Messages");
            DropIndex("dbo.Inboxes", new[] { "messsage_Id" });
            DropTable("dbo.Inboxes");
        }
    }
}
