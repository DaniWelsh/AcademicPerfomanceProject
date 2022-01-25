using Database.Models;
using Database.Repositories.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Course;
using Infrastructure.Services.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    /// <summary>
    ///    Course service 
    /// </summary>
    public class CourseService : ICourseService
        {
            public readonly ICourseRepository _courseRepository;

            public CourseService(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            /// <summary>
            ///     Get courses async
            /// </summary>
            /// <returns></returns>
            public async Task<List<CourseDto>> GetCoursesAsync()
            {
                List<Course> courses = await _courseRepository.GetCoursesAsync();
                return courses.Adapt<List<CourseDto>>();
            }

            /// <summary>
            ///     Get course by id async
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<CourseDto> GetCourseByIdAsync(int id)
            {
                Course course = await _courseRepository.GetCourseByIdAsync(id);
                return course.Adapt<CourseDto>();
            }

            /// <summary>
            ///     Create course async
            /// </summary>
            /// <param name="courseDto"></param>
            /// <returns></returns>
            public async Task<CreateCourseResponseModel> CreateCourseAsync(CourseDto courseDto)
            {
                Course course = courseDto.Adapt<Course>();
                Course courseCreated = await _courseRepository.CreateCourseAsync(course);

                return new CreateCourseResponseModel()
                {
                    Type = CourseResponseType.Success,
                    Course = courseCreated.Adapt<CourseDto>()
                };
            }

            /// <summary>
            ///     Edit course async
            /// </summary>
            /// <param name="id"></param>
            /// <param name="courseDto"></param>
            /// <returns></returns>
            public async Task<EditCourseResponseModel> EditCourseAsync(int id, CourseDto courseDto)
            {
                Course course = await _courseRepository.GetCourseByIdAsync(id);

                if (course == null)
                {
                    return new EditCourseResponseModel()
                    {
                        Type = CourseResponseType.CourseNotFound
                    };
                }

                courseDto.Id = course.Id;

                Course courseModel = courseDto.Adapt<Course>();
                Course courseEdited = await _courseRepository.EditCourseAsync(courseModel);

                return new EditCourseResponseModel()
                {
                    Type = CourseResponseType.Success,
                    Course = courseEdited.Adapt<CourseDto>()
                };
            }

            /// <summary>
            ///     Delete course async
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<CourseResponseType> DeleteCourseAsync(int id)
            {
                Course course = await _courseRepository.GetCourseByIdAsync(id);

                if (course == null)
                {
                    return CourseResponseType.CourseNotFound;
                }

                await _courseRepository.DeleteCourseAsync(course);

                return CourseResponseType.Success;
            }
    }
}

