using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Database
{
    public class StudentCourseDto
    {
        public int StudentId { get; set; }       
        public int CourseId { get; set; }        
        public int Rating { get; set; }
        public bool Debt { get; set; }
    }
}
