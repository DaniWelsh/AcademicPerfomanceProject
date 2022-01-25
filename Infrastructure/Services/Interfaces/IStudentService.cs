using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    /// <summary>
    ///    Interface for student service
    /// </summary>
    /// 
    public interface IStudentService
    {
        /// <summary>
        ///     Get students async
        /// </summary>
        /// <returns></returns>
        Task<List<StudentDto>> GetStudentsAsync();


        /// <summary>
        ///     Get student by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDto> GetStudentByIdAsync(int id);


        /// <summary>
        ///     Create student async
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        Task<CreateStudentResponseModel> CreateStudentAsync(StudentDto studentDto);


        /// <summary>
        ///     Edit student async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        Task<EditStudentResponseModel> EditStudentAsync(int id, StudentDto studentDto);


        /// <summary>
        ///     Delete student async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentResponseType> DeleteStudentAsync(int id);        
    }
}

