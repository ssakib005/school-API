using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentRegistrationWithAPI.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; } 
        public DbSet<Student> Students { get; set; }
    }
}