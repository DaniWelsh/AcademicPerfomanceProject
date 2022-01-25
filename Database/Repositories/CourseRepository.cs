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
    ///     Course repository
    /// </summary>
    public class CourseRepository : ICourseRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CourseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get courses async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _databaseContext.Courses.ToListAsync();
        }

        /// <summary>
        ///     Get course by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _databaseContext.Courses.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        ///     Create course async
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<Course> CreateCourseAsync(Course course)
        {
            _databaseContext.Courses.Add(course);
            await _databaseContext.SaveChangesAsync();

            return course;
        }

        /// <summary>
        ///     Edit course async 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<Course> EditCourseAsync(Course course)
        {
            _databaseContext.Courses.Update(course);
            await _databaseContext.SaveChangesAsync();

            return course;
        }

        /// <summary>
        ///     Delete course async 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task DeleteCourseAsync(Course course)
        {
            _databaseContext.Courses.Remove(course);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
