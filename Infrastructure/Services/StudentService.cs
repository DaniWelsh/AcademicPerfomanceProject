using Database.Models;
using Database.Repositories.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Models.Database;
using Infrastructure.Models.Services.Student;
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
    ///    Student service 
    /// </summary>
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        ///     Get students async
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            List<Student> students = await _studentRepository.GetStudentsAsync();
            return students.Adapt<List<StudentDto>>();
        }

        /// <summary>
        ///     Get student by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);
            return student.Adapt<StudentDto>();
        }

        /// <summary>
        ///     Create student async
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        public async Task<CreateStudentResponseModel> CreateStudentAsync(StudentDto studentDto)
        {
            Student student = studentDto.Adapt<Student>();
            Student studentCreated = await _studentRepository.CreateStudentAsync(student);

            return new CreateStudentResponseModel() { 
                Type = StudentResponseType.Success,
                Student = studentCreated.Adapt<StudentDto>()
            };
        }

        /// <summary>
        ///     Edit student async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        public async Task<EditStudentResponseModel> EditStudentAsync(int id, StudentDto studentDto)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return new EditStudentResponseModel()
                {
                    Type = StudentResponseType.StudentNotFound
                };
            }

            studentDto.Id = student.Id;

            Student studentModel = studentDto.Adapt<Student>();
            Student studentEdited = await _studentRepository.EditStudentAsync(studentModel);

            return new EditStudentResponseModel()
            {
                Type = StudentResponseType.Success,
                Student = studentEdited.Adapt<StudentDto>()
            };
        }

        /// <summary>
        ///     Delete student async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentResponseType> DeleteStudentAsync(int id)
        {
            Student student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return StudentResponseType.StudentNotFound;
            }

            await _studentRepository.DeleteStudentAsync(student);

            return StudentResponseType.Success;
        }
    }
}
