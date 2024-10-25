using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Anastasia_Erileeva_kt_42_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Индентифиатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: true, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы"),
                    Deletionstatus = table.Column<bool>(name: "Deletion status", type: "bool", nullable: false, comment: "Статус удаления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    c_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                    table.ForeignKey(
                        name: "fk_c_group_id",
                        column: x => x.c_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_subject_fk_c_group_id",
                table: "cd_subject",
                column: "c_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
