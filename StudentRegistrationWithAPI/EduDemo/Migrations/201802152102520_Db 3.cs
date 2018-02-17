namespace EduDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students");
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Subjects");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            AddColumn("dbo.Departments", "Student_Id", c => c.Int());
            AddColumn("dbo.Departments", "Subject_Id", c => c.Int());
            AddColumn("dbo.Departments", "Student_Id1", c => c.Int());
            AddColumn("dbo.Departments", "Subject_Id1", c => c.Int());
            AddColumn("dbo.Students", "Subject_Id", c => c.Int());
            AddColumn("dbo.Students", "Department_Id", c => c.Int());
            AddColumn("dbo.Subjects", "Student_Id", c => c.Int());
            AddColumn("dbo.Subjects", "Student_Id1", c => c.Int());
            AddColumn("dbo.Subjects", "Department_Id", c => c.Int());
            CreateIndex("dbo.Departments", "Student_Id");
            CreateIndex("dbo.Departments", "Subject_Id");
            CreateIndex("dbo.Departments", "Student_Id1");
            CreateIndex("dbo.Departments", "Subject_Id1");
            CreateIndex("dbo.Students", "Subject_Id");
            CreateIndex("dbo.Students", "Department_Id");
            CreateIndex("dbo.Subjects", "Student_Id");
            CreateIndex("dbo.Subjects", "Student_Id1");
            CreateIndex("dbo.Subjects", "Department_Id");
            AddForeignKey("dbo.Departments", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Departments", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Subjects", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Subjects", "Student_Id1", "dbo.Students", "Id");
            AddForeignKey("dbo.Departments", "Student_Id1", "dbo.Students", "Id");
            AddForeignKey("dbo.Departments", "Subject_Id1", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Students", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Subjects", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropTable("dbo.StudentCourse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId });
            
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Subjects", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Students", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Subject_Id1", "dbo.Subjects");
            DropForeignKey("dbo.Departments", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.Subjects", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Departments", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Departments", "Student_Id", "dbo.Students");
            DropIndex("dbo.Subjects", new[] { "Department_Id" });
            DropIndex("dbo.Subjects", new[] { "Student_Id1" });
            DropIndex("dbo.Subjects", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "Department_Id" });
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.Departments", new[] { "Subject_Id1" });
            DropIndex("dbo.Departments", new[] { "Student_Id1" });
            DropIndex("dbo.Departments", new[] { "Subject_Id" });
            DropIndex("dbo.Departments", new[] { "Student_Id" });
            DropColumn("dbo.Subjects", "Department_Id");
            DropColumn("dbo.Subjects", "Student_Id1");
            DropColumn("dbo.Subjects", "Student_Id");
            DropColumn("dbo.Students", "Department_Id");
            DropColumn("dbo.Students", "Subject_Id");
            DropColumn("dbo.Departments", "Subject_Id1");
            DropColumn("dbo.Departments", "Student_Id1");
            DropColumn("dbo.Departments", "Subject_Id");
            DropColumn("dbo.Departments", "Student_Id");
            CreateIndex("dbo.StudentCourse", "CourseRefId");
            CreateIndex("dbo.StudentCourse", "StudentRefId");
            AddForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
