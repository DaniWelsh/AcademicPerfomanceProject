
using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.StudentCourse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface IStudentCourseService
    {
        /// <summary>
        ///     Get student courses async
        /// </summary>
        /// <returns></returns>
        Task<List<StudentCourseDto>> GetStudentCoursesAsync();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<StudentCourseDto> GetStudentCourseByIdAsync(int StudentId, int CourseId);
       


        /// <summary>
        ///     Get student course by rating async
        /// </summary>
        /// <param name="ratingMin"></param>
        /// <param name="ratingMax"></param>
        /// <returns></returns>
        Task<List<StudentCourseDto>> GetStudentCoursesByRatingAsync(int ratingMin, int ratingMax);


        /// <summary>
        ///     Create student course async
        /// </summary>
        /// <param name="studentcourseDto"></param>
        /// <returns></returns>
        Task<CreateStudentCourseResponseModel> CreateStudentCourseAsync(StudentCourseDto studentcourseDto);


        /// <summary>
        ///     Edit student course async
        /// </summary>
        /// <param name="StudentId, CourseId"></param>
        /// <param name="studentcourseDto"></param>
        /// <returns></returns>
        Task<EditStudentCourseResponseModel> EditStudentCourseAsync(int StudentId, int CourseId, StudentCourseDto studentcourseDto);


        /// <summary>
        ///     Delete student course async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentCourseResponseType> DeleteStudentCourseAsync(int StudentId, int CourseId);        
    }
}
