using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb2Linq.Migrations
{
    /// <inheritdoc />
    public partial class fixtwotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Acceptance",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acceptance",
                table: "Enrollments");
        }
    }
}
