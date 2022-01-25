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
using Infrastructure.Models.Services.Student;

namespace AcademicPerfomance.AcademicPerfomance.Tests.Services
{
    /// <summary>
    ///     Student service test
    /// </summary>
    public class StudentServiceTest
    {
        Mock<IStudentRepository> studentRepositoryMock;       
        public StudentServiceTest()
        {
            studentRepositoryMock = new Mock<IStudentRepository>();            
        }

        [Fact]
        public async Task GetStudents_ShouldReturn_Students()
        {
            //arrange
            var students = GetTestStudents();

            studentRepositoryMock.Setup(r => r.GetStudentsAsync()).Returns(Task.FromResult(students.Adapt<List<Student>>()));
            StudentService service = new StudentService(studentRepositoryMock.Object);

            //act
            List<StudentDto> result = await service.GetStudentsAsync();

            //assert
            students.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetStudentById_ShouldReturn_Student()
        {
            //arrange
            var students = GetTestStudents();

            studentRepositoryMock.Setup(r => r.GetStudentByIdAsync(students[0].Id)).Returns(Task.FromResult(students[0].Adapt<Student>()));

            StudentService service = new StudentService(studentRepositoryMock.Object);

            //act
            StudentDto result = await service.GetStudentByIdAsync(students[0].Id);

            //assert
            students[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddStudent_ShouldReturn_Student()
        {
            //arrange
            StudentDto student = new StudentDto()
            {
                Id = 11,
                FirstName = "Daniil",
                LastName = "Volodkin"
            };

            studentRepositoryMock.Setup(r => r.CreateStudentAsync(student.Adapt<Student>())).Returns(Task.FromResult(student.Adapt<Student>()));

            StudentService service = new StudentService(studentRepositoryMock.Object);

            //act
            CreateStudentResponseModel result = await service.CreateStudentAsync(student);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.StudentResponseType.Success);
        }


        private List<StudentDto> GetTestStudents()
        {
            List<StudentDto> students = new List<StudentDto>
            {
                new StudentDto
                {                    
                    Id = 1,
                    FirstName = "Karl",
                    LastName = "Marx",                    
                },

                new StudentDto
                {
                    Id = 2,
                    FirstName = "Markus",
                    LastName = "Possiy",
                }
            };

            return students;
        }


    }
}
   
