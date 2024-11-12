using Anastasia_Erileeva_kt_42_21.Database;
using Anastasia_Erileeva_kt_42_21.Filters.StudentFilters;
using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Anastasia_Erileeva_kt_42_21.Interfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFamiliaAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFamiliaAllAsync(StudentFioAllFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;

        }

        public Task<Student[]> GetStudentsByFamiliaAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>()
                .Where(w =>(string.IsNullOrEmpty(filter.FirstName) || w.FirstName.Contains(filter.FirstName))&&
                    (string.IsNullOrEmpty(filter.LastName) || w.LastName.Contains(filter.LastName)) 
                    
                )
                .ToArrayAsync(cancellationToken);

            return students;
        }


        //public Task<Student[]> GetStudentsByFamiliaAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        //{
        //    var students = _dbContext.Set<Student>()
        //        .Where(w =>
        //    (string.IsNullOrEmpty(filter.LastName) || w.LastName == filter.LastName) &&
        //    (string.IsNullOrEmpty(filter.FirstName) || w.FirstName == filter.FirstName)).ToArrayAsync(cancellationToken);
        //    //.Where(w =>(w.LastName == filter.FIO) ).ToArrayAsync(cancellationToken);
        //    //поиск по имени, фамилии или отчеству
        //    //.Where(w => (w.FirstName == filter.FIO) || (w.LastName == filter.FIO) || (w.Middlename == filter.FIO)).ToArrayAsync(cancellationToken);
        //    //.Where(w => w.DeletionStatus == filter.DeletionStatus).ToArrayAsync(cancellationToken);
        //    return students;
        //}
        public Task<Student[]> GetStudentsByDeletionStatusAsync(StudentDeletionStatusFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>()
                .Where(w => w.DeletionStatus == filter.DeletionStatus).ToArrayAsync(cancellationToken);
            return students;
        }

        public Task<Student[]> GetStudentsByFamiliaAllAsync(StudentFioAllFilter filter, CancellationToken cancellationToken)
        {
            var students = _dbContext.Set<Student>()
                  //поиск по имени, фамилии и отчеству
                  .Where(w => (w.FirstName == filter.Name) & (w.LastName == filter.LastName) & (w.Middlename == filter.MiddleName)).ToArrayAsync(cancellationToken);
            //.Where(w => w.DeletionStatus == filter.DeletionStatus).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}