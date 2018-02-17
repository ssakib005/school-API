using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentRegistrationWithAPI.Models
{
    public class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int DepartmentId { get; set; }  
        public Department Department { get; set; }
        
    }
}