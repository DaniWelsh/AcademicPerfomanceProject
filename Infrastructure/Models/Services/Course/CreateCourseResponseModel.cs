using Infrastructure.Enums;
using Infrastructure.Models.Database;

namespace Infrastructure.Models.Services.Course
{
    public class CreateCourseResponseModel
    {
        public CourseResponseType Type { get; set; }
        public CourseDto Course { get; set; }
    }
}
