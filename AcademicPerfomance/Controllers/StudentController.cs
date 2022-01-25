using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Student;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPerfomance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            List<StudentDto> students = await _studentService.GetStudentsAsync();

            return Ok(students);
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            StudentDto student = await _studentService.GetStudentByIdAsync(id);

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto student)
        {
            CreateStudentResponseModel createStudentResponse = await _studentService.CreateStudentAsync(student);

            if (createStudentResponse.Type == StudentResponseType.Success)
            {
                return Ok(createStudentResponse);
            }

            return BadRequest(createStudentResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentDto student)
        {
            EditStudentResponseModel editStudentResponse = await _studentService.EditStudentAsync(id, student);

            if (editStudentResponse.Type == StudentResponseType.Success)
            {
                return Ok(editStudentResponse);
            }

            return BadRequest(editStudentResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            StudentResponseType studentResponse = await _studentService.DeleteStudentAsync(id);

            if (studentResponse == StudentResponseType.Success)
            {
                return Ok(studentResponse);
            }

            return BadRequest(studentResponse);
        }
    }
}
