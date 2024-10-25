using Anastasia_Erileeva_kt_42_21.Database.Configurations;
using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Anastasia_Erileeva_kt_42_21.Database
{
    public class StudentDbContext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }
    }
}