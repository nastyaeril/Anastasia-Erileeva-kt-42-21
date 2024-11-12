using Anastasia_Erileeva_kt_42_21.Database;
using Anastasia_Erileeva_kt_42_21.Interfaces;
using Anastasia_Erileeva_kt_42_21.Models;
using Anastasia_Erileeva_kt_42_21.Filters;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnastasiaErileevaKt_42_21.Tests
{
    public class FioTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public FioTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4221_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "КТ-42-21"
                },
                new Group
                {
                    GroupName = "КТ-41-21"
                },
                new Group
                {
                    GroupName = "КТ-31-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "A",
                    LastName = "A",
                    Middlename = "A",
                    GroupID = 1,
                    DeletionStatus = false,
                },
                new Student
                {
                    FirstName = "A",
                    LastName = "A",
                    Middlename = "A",
                    GroupID = 3,
                    DeletionStatus = true,
                },
                new Student
                {
                    FirstName = "A",
                    LastName = "A",
                    Middlename = "B",
                    GroupID = 1,
                    DeletionStatus = true,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            var filterFIO = new Anastasia_Erileeva_kt_42_21.Filters.StudentFilters.StudentFioAllFilter
            {
                Name = "A",
                LastName = "A",
                MiddleName = "A",
            };
            var studentsResult = await studentService.GetStudentsByFamiliaAllAsync(filterFIO, CancellationToken.None);

            Assert.Equal(2, studentsResult.Length);
        }
    }
}