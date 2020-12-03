namespace RAD3012021Week4.ClubDomain.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClubContextSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubEvent",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Venue = c.String(),
                        Location = c.String(),
                        ClubId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        ClubName = c.String(),
                        CreationDate = c.DateTime(nullable: false, storeType: "date"),
                        adminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        AssociatedClub = c.Int(nullable: false),
                        StudentID = c.String(maxLength: 128),
                        approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Club", t => t.AssociatedClub, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.AssociatedClub)
                .Index(t => t.StudentID);
            
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
            
            CreateTable(
                "dbo.EventAttendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventID = c.Int(nullable: false),
                        AttendeeMember = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ClubEvent", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.AttendeeMember)
                .Index(t => t.EventID)
                .Index(t => t.AttendeeMember);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventAttendances", "AttendeeMember", "dbo.Member");
            DropForeignKey("dbo.EventAttendances", "EventID", "dbo.ClubEvent");
            DropForeignKey("dbo.ClubEvent", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Member", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Member", "AssociatedClub", "dbo.Club");
            DropIndex("dbo.EventAttendances", new[] { "AttendeeMember" });
            DropIndex("dbo.EventAttendances", new[] { "EventID" });
            DropIndex("dbo.Students", new[] { "CourseID" });
            DropIndex("dbo.Member", new[] { "StudentID" });
            DropIndex("dbo.Member", new[] { "AssociatedClub" });
            DropIndex("dbo.ClubEvent", new[] { "ClubId" });
            DropTable("dbo.EventAttendances");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Member");
            DropTable("dbo.Club");
            DropTable("dbo.ClubEvent");
        }
    }
}
