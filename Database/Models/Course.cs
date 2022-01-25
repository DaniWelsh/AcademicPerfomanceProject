using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
