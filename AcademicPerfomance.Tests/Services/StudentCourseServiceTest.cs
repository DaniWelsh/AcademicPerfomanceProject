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
using Infrastructure.Models.Services.StudentCourse;

namespace AcademicPerfomance.AcademicPerfomance.Tests.Services
{
    /// <summary>
    ///     StudentCourse service test
    /// </summary>
    public class StudentCourseServiceTest
    {
        Mock<IStudentCourseRepository> studentcourseRepositoryMock;       
        public StudentCourseServiceTest()
        {
            studentcourseRepositoryMock = new Mock<IStudentCourseRepository>();            
        }

        [Fact]
        public async Task GetStudentCourses_ShouldReturn_StudentCourses()
        {
            //arrange
            var studentcourses = GetTestStudentCourses();

            studentcourseRepositoryMock.Setup(r => r.GetStudentCoursesAsync()).Returns(Task.FromResult(studentcourses.Adapt<List<StudentCourse>>()));
            StudentCourseService service = new StudentCourseService(studentcourseRepositoryMock.Object);

            //act
            List<StudentCourseDto> result = await service.GetStudentCoursesAsync();

            //assert
            studentcourses.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetStudentCourseById_ShouldReturn_StudentCourse()
        {
            //arrange
            var studentcourses = GetTestStudentCourses();

            studentcourseRepositoryMock.Setup(r => r.GetStudentCourseByIdAsync(studentcourses[0].StudentId , studentcourses[0].CourseId)).Returns(Task.FromResult(studentcourses[0].Adapt<StudentCourse>()));

            StudentCourseService service = new StudentCourseService(studentcourseRepositoryMock.Object);

            //act
            StudentCourseDto result = await service.GetStudentCourseByIdAsync(studentcourses[0].StudentId , studentcourses[0].CourseId);

            //assert
            studentcourses[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddStudentCourse_ShouldReturn_StudentCourse()
        {
            //arrange
            StudentCourseDto studentcourse = new StudentCourseDto()
            {
                StudentId = 11,                
                CourseId = 1,                
                Rating = 5,
                Debt = false,                
            };

            studentcourseRepositoryMock.Setup(r => r.CreateStudentCourseAsync(studentcourse.Adapt<StudentCourse>())).Returns(Task.FromResult(studentcourse.Adapt<StudentCourse>()));

            StudentCourseService service = new StudentCourseService(studentcourseRepositoryMock.Object);

            //act
            CreateStudentCourseResponseModel result = await service.CreateStudentCourseAsync(studentcourse);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.StudentCourseResponseType.Success);
        }


        private List<StudentCourseDto> GetTestStudentCourses()
        {
            List<StudentCourseDto> studentcourses = new List<StudentCourseDto>
            {
                new StudentCourseDto
                {
                StudentId = 12,
                CourseId = 3,
                Rating = 3,
                Debt = false,
                },

                new StudentCourseDto
                {
                StudentId = 2,
                CourseId = 5,
                Rating = 1,
                Debt = true,
                }
            };

            return studentcourses;
        }


    }
}
   
