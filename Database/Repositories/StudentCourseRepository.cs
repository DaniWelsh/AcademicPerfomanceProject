using Database.Models;
using Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{ 
  /// <summary>
  ///     Student course repository
  /// </summary>
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StudentCourseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get student courses async
        /// </summary>
        /// <returns></returns>
        public async Task<List<StudentCourse>> GetStudentCoursesAsync()
        {
            return await _databaseContext.StudentCourse.ToListAsync();
        }

        /// <summary>
        ///     Get student course by StudentId and CourseId async
        /// </summary>
        /// <param name="StudentId"></param>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<StudentCourse> GetStudentCourseByIdAsync(int StudentId, int CourseId)
        {
            return await _databaseContext.StudentCourse.FirstOrDefaultAsync(s => s.StudentId == StudentId && s.CourseId == CourseId);
        }

        /// <summary>
        ///     Get student course by rating async
        /// </summary>
        /// <param name="ratingMin"></param>
        /// <param name="ratingMax"></param>
        /// <returns></returns>
        public async Task<List<StudentCourse>> GetStudentCoursesByRatingAsync(int ratingMin, int ratingMax)
        {
            return await _databaseContext.StudentCourse.Where(s => s.Rating > ratingMin && s.Rating < ratingMax).ToListAsync();
        }
        

        /// <summary>
        ///     Create student course async
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        public async Task<StudentCourse> CreateStudentCourseAsync(StudentCourse studentCourse)
        {
            _databaseContext.StudentCourse.Add(studentCourse);
            await _databaseContext.SaveChangesAsync();

            return studentCourse;
        }

        /// <summary>
        ///     Edit student course async 
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        public async Task<StudentCourse> EditStudentCourseAsync(StudentCourse studentCourse)
        {
            _databaseContext.StudentCourse.Update(studentCourse);
            await _databaseContext.SaveChangesAsync();

            return studentCourse;
        }

        /// <summary>
        ///     Delete student course async 
        /// </summary>
        /// <param name="studentCourse"></param>
        /// <returns></returns>
        public async Task<StudentCourse> DeleteStudentCourseAsync(StudentCourse studentCourse)
        {
            _databaseContext.StudentCourse.Remove(studentCourse);
            await _databaseContext.SaveChangesAsync();

            return studentCourse;
        }
    }
}
