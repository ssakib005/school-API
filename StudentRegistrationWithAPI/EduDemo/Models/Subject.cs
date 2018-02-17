using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EduDemo.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Subject
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public string Code { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } 
        public virtual ICollection<Student> Students { get; set; } 
    }
}