using Infrastructure.Enums;
using Infrastructure.Models.Database;

namespace Infrastructure.Models.Services.Student
{
    public class CreateStudentResponseModel
    {
        public StudentResponseType Type { get; set; }
        public StudentDto Student { get; set; }
    }
}
