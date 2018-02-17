using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models;

namespace StudentRegistrationWithAPI.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; } 
        public DbSet<Student> Students { get; set; }
    }
}