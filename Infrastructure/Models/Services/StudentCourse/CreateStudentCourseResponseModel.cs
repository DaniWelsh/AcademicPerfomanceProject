using Infrastructure.Enums;
using Infrastructure.Models.Database;

namespace Infrastructure.Models.Services.StudentCourse
{
    public class CreateStudentCourseResponseModel
    {
        public StudentCourseResponseType Type { get; set; }
        public StudentCourseDto StudentCourse { get; set; }
    }
}
