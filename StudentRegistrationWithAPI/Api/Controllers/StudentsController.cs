using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;
using StudentRegistrationWithAPI.Models;

namespace Api.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentDbContext db = new StudentDbContext();

        Student stu = new Student();

        // GET: api/Students
        public IEnumerable<Student> GetStudents()
        {
            var studentsList = db.Students.ToList();

            return studentsList;
        }

        // GET: api/Students/5
        public IHttpActionResult GetStudents(int id)
        {
            var student = CreateStudentSObjects().FirstOrDefault(c => c.Id == id);
            var jsonData = new
            {
                Id = student.Id,
                Address = student.Address,
                Contact = student.Contact,
                Email = student.Email,
                Name = student.Name
            };
            return Json(jsonData);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudents(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudents(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }

        public List<Student> CreateStudentSObjects()
        {
            Student s1 = new Student()
            {
                Id = 1,
                Name = "aa",
                RegistrationNo = "006",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s2 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111",
                Subject = "ETE 282",
                DepName = "CSE"

            };
            Student s3 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s4 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s5 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s6 = new Student()
            {
                Id = 2,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s7 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            Student s8 = new Student()
            {
                Id = 1,
                Name = "aa",
                Address = "bb",
                Email = "cc",
                Contact = "111"

            };
            List<Student> studentList = new List<Student>();
            studentList.Add(s1);
            studentList.Add(s2);
            studentList.Add(s3);
            studentList.Add(s4);
            studentList.Add(s5);
            studentList.Add(s6);
            studentList.Add(s7);
            studentList.Add(s8);

            return studentList;
        }
    }
}
