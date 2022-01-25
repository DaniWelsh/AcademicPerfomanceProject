using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for Student course repository 
    /// </summary>
    public interface IStudentCourseRepository
    {

        /// <summary>
        ///     Get student courses async
        /// </summary>
        /// <returns></returns>
        Task<List<StudentCourse>> GetStudentCoursesAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<StudentCourse> GetStudentCourseByIdAsync(int StudentId, int CourseId);       

        /// <summary>
        ///     Get students by rating async
        /// </summary>
        /// <param name="ratingMin"></param>
        /// <param name="ratingMax"></param>
        /// <returns></returns>
        Task<List<StudentCourse>> GetStudentCoursesByRatingAsync(int ratingMin, int ratingMax);

        /// <summary>
        ///     Create studentCourse async
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        Task<StudentCourse> CreateStudentCourseAsync(StudentCourse studentCourse);

        /// <summary>
        ///     Edit studentCourse async 
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        Task<StudentCourse> EditStudentCourseAsync(StudentCourse studentCourse);


        /// <summary>
        ///     Delete studentCourse async 
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        Task<StudentCourse> DeleteStudentCourseAsync(StudentCourse studentCourse);     
    }
}
