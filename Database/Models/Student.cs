using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Student
    {
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        
        public List<Course> Courses { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
