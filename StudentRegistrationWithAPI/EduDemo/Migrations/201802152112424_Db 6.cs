namespace EduDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.Departments", "Subject_Id1", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "Subject_Id" });
            DropIndex("dbo.Departments", new[] { "Subject_Id1" });
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.Subjects", new[] { "Student_Id" });
            DropIndex("dbo.Subjects", new[] { "Student_Id1" });
            DropIndex("dbo.Subjects", new[] { "Department_Id" });
            CreateTable(
                "dbo.SubjectDepartments",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Department_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Student_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Student_Id);
            
            DropColumn("dbo.Departments", "Subject_Id");
            DropColumn("dbo.Departments", "Subject_Id1");
            DropColumn("dbo.Students", "Subject_Id");
            DropColumn("dbo.Subjects", "Student_Id");
            DropColumn("dbo.Subjects", "Student_Id1");
            DropColumn("dbo.Subjects", "Department_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Department_Id", c => c.Int());
            AddColumn("dbo.Subjects", "Student_Id1", c => c.Int());
            AddColumn("dbo.Subjects", "Student_Id", c => c.Int());
            AddColumn("dbo.Students", "Subject_Id", c => c.Int());
            AddColumn("dbo.Departments", "Subject_Id1", c => c.Int());
            AddColumn("dbo.Departments", "Subject_Id", c => c.Int());
            DropForeignKey("dbo.SubjectStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.SubjectDepartments", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectStudents", new[] { "Student_Id" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectDepartments", new[] { "Department_Id" });
            DropIndex("dbo.SubjectDepartments", new[] { "Subject_Id" });
            DropTable("dbo.SubjectStudents");
            DropTable("dbo.SubjectDepartments");
            CreateIndex("dbo.Subjects", "Department_Id");
            CreateIndex("dbo.Subjects", "Student_Id1");
            CreateIndex("dbo.Subjects", "Student_Id");
            CreateIndex("dbo.Subjects", "DepartmentId");
            CreateIndex("dbo.Students", "Subject_Id");
            CreateIndex("dbo.Departments", "Subject_Id1");
            CreateIndex("dbo.Departments", "Subject_Id");
            AddForeignKey("dbo.Subjects", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Departments", "Subject_Id1", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Subjects", "Student_Id1", "dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Subjects", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Departments", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
