using Anastasia_Erileeva_kt_42_21.Database.Helpers;
using Anastasia_Erileeva_kt_42_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Anastasia_Erileeva_kt_42_21.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            //Первичный ключ
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            //Автогенерация первичного ключа
            builder.Property(p => p.SubjectId).ValueGeneratedOnAdd();

            //Идентификатор
            builder.Property(p => p.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("Идентификатор записи дисциплины");

            //Название дисциплины
            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("subject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("c_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            //Связь с таблицей Группа
            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany(t => t.Subject)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_c_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_c_group_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}