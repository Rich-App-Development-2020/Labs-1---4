namespace RAD3012021Week4.ClubDomain.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedClubsStudentsMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        CourseID = c.Int(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        Year = c.Int(nullable: false),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            AlterColumn("dbo.Member", "StudentID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Member", "StudentID");
            AddForeignKey("dbo.Member", "StudentID", "dbo.Students", "StudentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseID" });
            DropIndex("dbo.Member", new[] { "StudentID" });
            AlterColumn("dbo.Member", "StudentID", c => c.String());
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
        }
    }
}
