using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    /// <summary>
    ///    Interface for course service
    /// </summary>
    /// 
    public interface ICourseService
    {
        /// <summary>
        ///     Get courses async
        /// </summary>
        /// <returns></returns>
        Task<List<CourseDto>> GetCoursesAsync();


        /// <summary>
        ///     Get course by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CourseDto> GetCourseByIdAsync(int id);


        /// <summary>
        ///     Create course async
        /// </summary>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        Task<CreateCourseResponseModel> CreateCourseAsync(CourseDto courseDto);


        /// <summary>
        ///     Edit course async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseDto"></param>
        /// <returns></returns>
        Task<EditCourseResponseModel> EditCourseAsync(int id, CourseDto courseDto);


        /// <summary>
        ///     Delete course async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CourseResponseType> DeleteCourseAsync(int id);        
    }
}