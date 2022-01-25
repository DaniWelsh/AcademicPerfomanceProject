using Database.Models;
using Database.Repositories.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.StudentCourse;
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
    ///    Student course service 
    /// </summary>
    public class StudentCourseService : IStudentCourseService
    {
        public readonly IStudentCourseRepository _studentcourseRepository;

        public StudentCourseService(IStudentCourseRepository studentcourseRepository)
        {
            _studentcourseRepository = studentcourseRepository;
        }

        /// <summary>
        ///     Get student courses async
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentCourseDto>> GetStudentCoursesAsync()
        {
            List<StudentCourse> studentcourses = await _studentcourseRepository.GetStudentCoursesAsync();
            return studentcourses.Adapt<List<StudentCourseDto>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<StudentCourseDto> GetStudentCourseByIdAsync(int StudentId, int CourseId)
        {
            StudentCourse studentcourse = await _studentcourseRepository.GetStudentCourseByIdAsync(StudentId,CourseId);
            return studentcourse.Adapt<StudentCourseDto>();
        }

        /// <summary>
        ///     Get student course by rating async
        /// </summary>
        /// <param name="ratingMin"></param>
        /// <param name="ratingMax"></param>
        /// <returns></returns>
        public async Task<List<StudentCourseDto>> GetStudentCoursesByRatingAsync(int ratingMin, int ratingMax)
        {
            List<StudentCourse> studentcourses = await _studentcourseRepository.GetStudentCoursesByRatingAsync(ratingMin, ratingMax);
            return studentcourses.Adapt<List<StudentCourseDto>>();
        }

        /// <summary>
        ///     Create student course async
        /// </summary>
        /// <param name="studentcourseDto"></param>
        /// <returns></returns>
        public async Task<CreateStudentCourseResponseModel> CreateStudentCourseAsync(StudentCourseDto studentcourseDto)
        {
            StudentCourse studentcourse = studentcourseDto.Adapt<StudentCourse>();
            StudentCourse studentcourseCreated = await _studentcourseRepository.CreateStudentCourseAsync(studentcourse);

            return new CreateStudentCourseResponseModel()
            {
                Type = StudentCourseResponseType.Success,
                StudentCourse = studentcourseCreated.Adapt<StudentCourseDto>()
            };
        }

        /// <summary>
        ///     Edit student course async
        /// </summary>
        /// <param name="StudentId, CourseId"></param>
        /// <param name="studentcourseDto"></param>
        /// <returns></returns>
        public async Task<EditStudentCourseResponseModel> EditStudentCourseAsync(int StudentId, int CourseId, StudentCourseDto studentcourseDto)
        {
            StudentCourse studentcourse = await _studentcourseRepository.GetStudentCourseByIdAsync(StudentId, CourseId);

            if (studentcourse == null)
            {
                return new EditStudentCourseResponseModel()
                {
                    Type = StudentCourseResponseType.StudentCourseNotFound
                };
            }

            studentcourseDto.StudentId = studentcourse.CourseId;

            StudentCourse studentcourseModel = studentcourseDto.Adapt<StudentCourse>();
            StudentCourse studentcourseEdited = await _studentcourseRepository.EditStudentCourseAsync(studentcourseModel);

            return new EditStudentCourseResponseModel()
            {
                Type = StudentCourseResponseType.Success,
                StudentCourse = studentcourseEdited.Adapt<StudentCourseDto>()
            };
        }

        /// <summary>
        ///     Delete student course async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentCourseResponseType> DeleteStudentCourseAsync(int StudentId, int CourseId)
        {
            StudentCourse studentcourse = await _studentcourseRepository.GetStudentCourseByIdAsync(StudentId, CourseId);

            if (studentcourse == null)
            {
                return StudentCourseResponseType.StudentCourseNotFound;
            }

            await _studentcourseRepository.DeleteStudentCourseAsync(studentcourse);

            return StudentCourseResponseType.Success;
        }
    }
}
