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
    ///     Course repository test
    /// </summary>
    public class CourseRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public CourseRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetCourses_ShouldReturn_Courses()
        {
            //arange
            ClearDatabase(context);

            var coursesNew = AddDb(context);

            var courseRepository = new CourseRepository(context);

            //act
            var result = await courseRepository.GetCoursesAsync();

            //assert
            coursesNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetCourseById_ShouldReturn_Course()
        {
            //arrange
            ClearDatabase(context);

            var coursesNew = AddDb(context);

            var courseRepository = new CourseRepository(context);

            //act
            var result = await courseRepository.GetCourseByIdAsync(coursesNew[0].Id);

            //assert
            coursesNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddCourse_ShouldReturn_Course()
        {
            //arrange
            var course = new Course
            {
                Id = 1,
                Name = "History",
            };

            var courseRepository = new CourseRepository(context);

            //act
            var result = await courseRepository.CreateCourseAsync(course);

            //assert
            course.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditCourse_ShouldReturn_Course()
        {
            //arrange
            ClearDatabase(context);

            var coursesNew = AddDb(context);
            var courseRepository = new CourseRepository(context);

            //act
            var result = await courseRepository.EditCourseAsync(coursesNew[0]);

            //assert
            coursesNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteCourse_ShouldReturn_Course()
        {
            //arrange
            ClearDatabase(context);

            var coursesNew = AddDb(context);
            var courseRepository = new CourseRepository(context);

            //act
            await courseRepository.DeleteCourseAsync(coursesNew[1]);

            //assert
            Assert.True(context.Courses.FirstOrDefault(t => t.Id == coursesNew[1].Id) == null);
        }

        private Course[] AddDb(DatabaseContext database)
        {
            var coursesNew = new[] {

                new Course
                {
                Id = 5,
                Name = "Art",
                },

                new Course
                {
                     Id = 6,
                Name = "Math",
                }
            };

            database.Courses.AddRange(coursesNew);
            database.SaveChanges();

            return coursesNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Courses)
                context.Courses.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}

