using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for course repository 
    /// </summary>
   public interface ICourseRepository
    {
        /// <summary>
        ///     Get courses async
        /// </summary>
        /// <returns></returns>
        Task<List<Course>> GetCoursesAsync();

        /// <summary>
        ///     Get Course by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Course> GetCourseByIdAsync(int id);

        /// <summary>
        ///     Create course async
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<Course> CreateCourseAsync(Course course);

        /// <summary>
        ///     Edit course async 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        Task<Course> EditCourseAsync(Course course);

        
        /// <summary>
        ///     Delete Course async 
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        Task DeleteCourseAsync(Course course);
    }
}
