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
    ///     Student repository test
    /// </summary>
    public class StudentRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public StudentRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetStudents_ShouldReturn_Students()
        {
            //arange
            ClearDatabase(context);

            var studentsNew = AddDb(context);

            var studentRepository = new StudentRepository(context);

            //act
            var result = await studentRepository.GetStudentsAsync();

            //assert
            studentsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetStudentById_ShouldReturn_Student()
        {
            //arrange
            ClearDatabase(context);

            var studentsNew = AddDb(context);

            var studentRepository = new StudentRepository(context);

            //act
            var result = await studentRepository.GetStudentByIdAsync(studentsNew[0].Id);

            //assert
            studentsNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddStudent_ShouldReturn_Student()
        {
            //arrange
            var student = new Student
            {
                Id = 11,
                FirstName = "Daniil",
                LastName = "Volodkin"
            };

            var studentRepository = new StudentRepository(context);

            //act
            var result = await studentRepository.CreateStudentAsync(student);

            //assert
            student.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditStudent_ShouldReturn_Student()
        {
            //arrange
            ClearDatabase(context);

            var studentsNew = AddDb(context);
            var studentRepository = new StudentRepository(context);

            //act
            var result = await studentRepository.EditStudentAsync(studentsNew[0]);

            //assert
            studentsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteStudent_ShouldReturn_Student()
        {
            //arrange
            ClearDatabase(context);

            var studentsNew = AddDb(context);
            var studentRepository = new StudentRepository(context);

            //act
            await studentRepository.DeleteStudentAsync(studentsNew[1]);

            //assert
            Assert.True(context.Students.FirstOrDefault(t => t.Id == studentsNew[1].Id) == null);
        }

        private Student[] AddDb(DatabaseContext database)
        {
            var studentsNew = new[] {

                new Student
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Doe",
                },

                new Student
                {
                    Id = 2,
                    FirstName = "Petr",
                    LastName = "Krasnov",
                }
            };

            database.Students.AddRange(studentsNew);
            database.SaveChanges();

            return studentsNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Students)
                context.Students.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}

