using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for student repository 
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        ///     Get students async
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GetStudentsAsync();

        /// <summary>
        ///     Get student by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Student> GetStudentByIdAsync(int id);
              

        /// <summary>
        ///     Create student async
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<Student> CreateStudentAsync(Student student);

        /// <summary>
        ///     Edit student async 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<Student> EditStudentAsync(Student student);

        /// <summary>
        ///     Delete student async 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task DeleteStudentAsync(Student student);
    }
}
