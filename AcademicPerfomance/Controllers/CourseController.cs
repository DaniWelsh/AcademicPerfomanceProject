using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Course;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPerfomance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            List<CourseDto> courses = await _courseService.GetCoursesAsync();

            return Ok(courses);
        }

        [HttpGet("GetCourse/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            CourseDto course = await _courseService.GetCourseByIdAsync(id);

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseDto course)
        {
            CreateCourseResponseModel createCourseResponse = await _courseService.CreateCourseAsync(course);

            if (createCourseResponse.Type == CourseResponseType.Success)
            {
                return Ok(createCourseResponse);
            }

            return BadRequest(createCourseResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CourseDto course)
        {
            EditCourseResponseModel editCourseResponse = await _courseService.EditCourseAsync(id, course);

            if (editCourseResponse.Type == CourseResponseType.Success)
            {
                return Ok(editCourseResponse);
            }

            return BadRequest(editCourseResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CourseResponseType courseResponse = await _courseService.DeleteCourseAsync(id);

            if (courseResponse == CourseResponseType.Success)
            {
                return Ok(courseResponse);
            }

            return BadRequest(courseResponse);
        }
    }
}
