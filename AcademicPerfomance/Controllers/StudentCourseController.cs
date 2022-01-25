using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.StudentCourse;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPerfomance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentcourseService;

        public StudentCourseController(IStudentCourseService studentcourseService)
        {
            _studentcourseService = studentcourseService;
        }

        [HttpGet("GetStudentCourses")]
        public async Task<IActionResult> GetStudentCourses()
        {
            List<StudentCourseDto> studentcourses = await _studentcourseService.GetStudentCoursesAsync();

            return Ok(studentcourses);
        }

        [HttpGet("GetStudentCourse/{StudentId,CourseId}")]
        public async Task<IActionResult> GetStudentCourse(int StudentId, int CourseId)
        {
            StudentCourseDto studentcourse = await _studentcourseService.GetStudentCourseByIdAsync(StudentId, CourseId);

            return Ok(studentcourse);
        }

        [HttpGet("GetStudentCoursesByRating/{ratingMin, ratingMax}")]
        public async Task<IActionResult> GetStudentCoursesByRating (int ratingMin, int ratingMax)
        {
            List<StudentCourseDto> studentcourses = await _studentcourseService.GetStudentCoursesByRatingAsync(ratingMin, ratingMax);

            return Ok(studentcourses);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentCourseDto studentcourse)
        {
            CreateStudentCourseResponseModel createStudentCourseResponse = await _studentcourseService.CreateStudentCourseAsync(studentcourse);

            if (createStudentCourseResponse.Type == StudentCourseResponseType.Success)
            {
                return Ok(createStudentCourseResponse);
            }

            return BadRequest(createStudentCourseResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int StudentId,int CourseId, StudentCourseDto studentcourse)
        {
            EditStudentCourseResponseModel editStudentCourseResponse = await _studentcourseService.EditStudentCourseAsync(StudentId, CourseId, studentcourse);

            if (editStudentCourseResponse.Type == StudentCourseResponseType.Success)
            {
                return Ok(editStudentCourseResponse);
            }

            return BadRequest(editStudentCourseResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int StudentId, int CourseId)
        {
            StudentCourseResponseType studentcourseResponse = await _studentcourseService.DeleteStudentCourseAsync(StudentId, CourseId);

            if (studentcourseResponse == StudentCourseResponseType.Success)
            {
                return Ok(studentcourseResponse);
            }

            return BadRequest(studentcourseResponse);
        }
    }
}
