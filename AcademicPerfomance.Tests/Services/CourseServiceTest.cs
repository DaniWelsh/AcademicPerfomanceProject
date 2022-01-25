using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Infrastructure.Services;
using Database.Models;
using Infrastructure.Models.Database;
using Database.Repositories.Interfaces;
using Infrastructure.Models.Services.Course;

namespace AcademicPerfomance.AcademicPerfomance.Tests.Services
{
    /// <summary>
    ///     Course service test
    /// </summary>
    public class CourseServiceTest
    {
        Mock<ICourseRepository> courseRepositoryMock;       
        public CourseServiceTest()
        {
            courseRepositoryMock = new Mock<ICourseRepository>();            
        }

        [Fact]
        public async Task GetCourses_ShouldReturn_Courses()
        {
            //arrange
            var courses = GetTestCourses();

            courseRepositoryMock.Setup(r => r.GetCoursesAsync()).Returns(Task.FromResult(courses.Adapt<List<Course>>()));
            CourseService service = new CourseService(courseRepositoryMock.Object);

            //act
            List<CourseDto> result = await service.GetCoursesAsync();

            //assert
            courses.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetCourseById_ShouldReturn_Course()
        {
            //arrange
            var courses = GetTestCourses();

            courseRepositoryMock.Setup(r => r.GetCourseByIdAsync(courses[0].Id)).Returns(Task.FromResult(courses[0].Adapt<Course>()));

            CourseService service = new CourseService(courseRepositoryMock.Object);

            //act
            CourseDto result = await service.GetCourseByIdAsync(courses[0].Id);

            //assert
            courses[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddCourse_ShouldReturn_Course()
        {
            //arrange
            CourseDto course = new CourseDto()
            {
                Id = 1,
                Name = "History",                
            };

            courseRepositoryMock.Setup(r => r.CreateCourseAsync(course.Adapt<Course>())).Returns(Task.FromResult(course.Adapt<Course>()));

            CourseService service = new CourseService(courseRepositoryMock.Object);

            //act
            CreateCourseResponseModel result = await service.CreateCourseAsync(course);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.CourseResponseType.Success);
        }


        private List<CourseDto> GetTestCourses()
        {
            List<CourseDto> courses = new List<CourseDto>
            {
                new CourseDto
                {                    
                    Id = 2,
                    Name = "Math",                                       
                },

                new CourseDto
                {
                    Id = 2,
                    Name = "Markus",
                }
            };

            return courses;
        }


    }
}
   
