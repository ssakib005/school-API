namespace EduDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Student_Id1", "dbo.Students");
            DropIndex("dbo.Departments", new[] { "Student_Id1" });
            DropColumn("dbo.Departments", "Student_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Student_Id1", c => c.Int());
            CreateIndex("dbo.Departments", "Student_Id1");
            AddForeignKey("dbo.Departments", "Student_Id1", "dbo.Students", "Id");
        }
    }
}
