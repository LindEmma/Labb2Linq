using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2Linq.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentTeacherFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_FkTeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FkTeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FkTeacherId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "FkTeacherId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FkTeacherId",
                table: "Enrollments",
                column: "FkTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Teachers_FkTeacherId",
                table: "Enrollments",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Teachers_FkTeacherId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_FkTeacherId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "FkTeacherId",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "FkTeacherId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FkTeacherId",
                table: "Courses",
                column: "FkTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_FkTeacherId",
                table: "Courses",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }
    }
}
