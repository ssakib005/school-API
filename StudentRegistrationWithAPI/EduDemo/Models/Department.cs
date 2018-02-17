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
    public class Department
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Code { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Subject> Subjects { get; set; } 
    }
}