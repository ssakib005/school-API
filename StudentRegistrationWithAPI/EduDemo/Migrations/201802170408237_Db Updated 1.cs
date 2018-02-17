namespace EduDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbUpdated1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SubjectStudents", newName: "StudentCourse");
            DropForeignKey("dbo.Departments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectDepartments", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "Department_Id" });
            DropIndex("dbo.SubjectDepartments", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectDepartments", new[] { "Department_Id" });
            DropColumn("dbo.Students", "DepartmentId");
            RenameColumn(table: "dbo.Students", name: "Department_Id", newName: "DepartmentId");
            RenameColumn(table: "dbo.StudentCourse", name: "Subject_Id", newName: "CourseRefId");
            RenameColumn(table: "dbo.StudentCourse", name: "Student_Id", newName: "StudentRefId");
            RenameIndex(table: "dbo.StudentCourse", name: "IX_Student_Id", newName: "IX_StudentRefId");
            RenameIndex(table: "dbo.StudentCourse", name: "IX_Subject_Id", newName: "IX_CourseRefId");
            DropPrimaryKey("dbo.StudentCourse");
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentCourse", new[] { "StudentRefId", "CourseRefId" });
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.Subjects", "DepartmentId");
            AddForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id");
            DropColumn("dbo.Departments", "Student_Id");
            DropTable("dbo.SubjectDepartments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectDepartments",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Department_Id });
            
            AddColumn("dbo.Departments", "Student_Id", c => c.Int());
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropPrimaryKey("dbo.StudentCourse");
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int());
            AddPrimaryKey("dbo.StudentCourse", new[] { "Subject_Id", "Student_Id" });
            RenameIndex(table: "dbo.StudentCourse", name: "IX_CourseRefId", newName: "IX_Subject_Id");
            RenameIndex(table: "dbo.StudentCourse", name: "IX_StudentRefId", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.StudentCourse", name: "StudentRefId", newName: "Student_Id");
            RenameColumn(table: "dbo.StudentCourse", name: "CourseRefId", newName: "Subject_Id");
            RenameColumn(table: "dbo.Students", name: "DepartmentId", newName: "Department_Id");
            AddColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubjectDepartments", "Department_Id");
            CreateIndex("dbo.SubjectDepartments", "Subject_Id");
            CreateIndex("dbo.Students", "Department_Id");
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.Departments", "Student_Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectDepartments", "Department_Id", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectDepartments", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Departments", "Student_Id", "dbo.Students", "Id");
            RenameTable(name: "dbo.StudentCourse", newName: "SubjectStudents");
        }
    }
}
