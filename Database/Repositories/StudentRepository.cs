using Database.Models;
using Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    /// <summary>
    ///     Student repository
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StudentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get students async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _databaseContext.Students.ToListAsync();
        }

        /// <summary>
        ///     Get student by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _databaseContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
        

        /// <summary>
        ///     Create student async
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> CreateStudentAsync(Student student)
        {
            _databaseContext.Students.Add(student);
            await _databaseContext.SaveChangesAsync();

            return student;
        }

        /// <summary>
        ///     Edit student async 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> EditStudentAsync(Student student)
        {
            _databaseContext.Students.Update(student);
            await _databaseContext.SaveChangesAsync();

            return student;
        }

        /// <summary>
        ///     Delete student async 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task DeleteStudentAsync(Student student)
        {
            _databaseContext.Students.Remove(student);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
