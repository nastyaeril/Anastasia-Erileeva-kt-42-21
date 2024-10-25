using Anastasia_Erileeva_kt_42_21.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Anastasia_Erileeva_kt_42_21.Models;


namespace Anastasia_Erileeva_kt_42_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //Первичный ключ
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            //Автогенерация первичного ключа
            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Индентифиатор записи группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название группы");

            builder.ToTable(TableName);
        }
    }
}