using Database;
using Database.Models;
using Database.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AcademicPerfomance.Tests.Repositories
{
    /// <summary>
    ///     Student course repository test
    /// </summary>
    public class StudentCourseRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public StudentCourseRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetStudentCourses_ShouldReturn_StudentCourses()
        {
            //arange
            ClearDatabase(context);

            var studentcoursesNew = AddDb(context);

            var studentcourseRepository = new StudentCourseRepository(context);

            //act
            var result = await studentcourseRepository.GetStudentCoursesAsync();

            //assert
            studentcoursesNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetStudentCourseById_ShouldReturn_StudentCourse()
        {
            //arrange
            ClearDatabase(context);

            var studentcoursesNew = AddDb(context);

            var studentcourseRepository = new StudentCourseRepository(context);

            //act
            var result = await studentcourseRepository.GetStudentCourseByIdAsync(studentcoursesNew[0].StudentId, studentcoursesNew[0].CourseId);

            //assert
            studentcoursesNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddStudentCourse_ShouldReturn_StudentCourse()
        {
            //arrange
            var studentcourse = new StudentCourse
            {
                StudentId = 11,
                CourseId = 1,
                Rating = 5,
                Debt = false,
            };

            var studentcourseRepository = new StudentCourseRepository(context);

            //act
            var result = await studentcourseRepository.CreateStudentCourseAsync(studentcourse);

            //assert
            studentcourse.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditStudentCourse_ShouldReturn_StudentCourse()
        {
            //arrange
            ClearDatabase(context);

            var studentcoursesNew = AddDb(context);
            var studentcourseRepository = new StudentCourseRepository(context);

            //act
            var result = await studentcourseRepository.EditStudentCourseAsync(studentcoursesNew[0]);

            //assert
            studentcoursesNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteStudentCourse_ShouldReturn_StudentCourse()
        {
            //arrange
            ClearDatabase(context);

            var studentcoursesNew = AddDb(context);
            var studentcourseRepository = new StudentCourseRepository(context);

            //act
            await studentcourseRepository.DeleteStudentCourseAsync(studentcoursesNew[1]);

            //assert
            Assert.True(context.StudentCourse.FirstOrDefault(t => t.StudentId == studentcoursesNew[1].StudentId && t.CourseId == studentcoursesNew[1].CourseId) == null);
        }

        private StudentCourse[] AddDb(DatabaseContext database)
        {
            var studentcoursesNew = new[] {

                new StudentCourse
                {
                    StudentId = 1,
                CourseId = 4,
                Rating = 5,
                Debt = false,
                },

                new StudentCourse
                {
                    StudentId = 15,
                CourseId = 6,
                Rating = 1,
                Debt = true,
                }
            };

            database.StudentCourse.AddRange(studentcoursesNew);
            database.SaveChanges();

            return studentcoursesNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.StudentCourse)
                context.StudentCourse.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}

