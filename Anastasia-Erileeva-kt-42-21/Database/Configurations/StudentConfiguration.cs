using Anastasia_Erileeva_kt_42_21.Database.Helpers;
using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Anastasia_Erileeva_kt_42_21.Database.Configurations
{

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        //Название таблицы в БД
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //Для целочисленного первичного ключа задаем автогенерацию (+1)
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            //Расписывае, как будут называться колонки в БД, их обязательность и тд
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            //Имя
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");//HasComment добавляет комментарий, который будет отображаться в СУБД

            //Фамилия
            builder.Property(p => p.LastName)
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            //Отчество
            builder.Property(p => p.Middlename)
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

            //Идентификатор группы
            builder.Property(p => p.GroupID)
                .IsRequired()
                .HasColumnName("f_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            //Статус удаления
            builder.Property(p => p.DeletionStatus)
                .IsRequired()
                .HasColumnName("Deletion status")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Статус удаления");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupID)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupID, $"idx_{TableName}_fk_f_group_id");

            //Явная автоподгрузка связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}