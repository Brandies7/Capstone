namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshoppinglist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Quantity = c.Int(nullable: false),
                        Buy = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingLists", new[] { "User_Id" });
            DropTable("dbo.ShoppingLists");
        }
    }
}
