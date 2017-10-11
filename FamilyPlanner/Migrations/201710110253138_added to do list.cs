namespace FamilyPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtodolist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyToDoList = c.String(),
                        Completed = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ToDoLists", new[] { "User_Id" });
            DropTable("dbo.ToDoLists");
        }
    }
}
