using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationWithAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public List<Student> Students { get; set; }  
    }
}