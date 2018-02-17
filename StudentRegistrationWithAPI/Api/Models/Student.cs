using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegistrationNo { get; set; }  
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Subject { get; set; }
        public string DepName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}