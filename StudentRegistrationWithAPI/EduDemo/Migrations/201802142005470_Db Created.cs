namespace EduDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId })
                .ForeignKey("dbo.Students", t => t.StudentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRefId)
                .Index(t => t.CourseRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Subjects");
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
        }
    }
}
