namespace Lexicon_LMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Documents2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        GroupId = c.Int(),
                        CourseId = c.Int(),
                        ActivityId = c.Int(),
                        Title = c.String(),
                        FileName = c.String(),
                        Description = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId)
                .Index(t => t.CourseId)
                .Index(t => t.ActivityId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Documents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Documents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Documents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Documents", new[] { "ActivityId" });
            DropIndex("dbo.Documents", new[] { "CourseId" });
            DropIndex("dbo.Documents", new[] { "GroupId" });
            DropTable("dbo.Documents");
        }
    }
}
