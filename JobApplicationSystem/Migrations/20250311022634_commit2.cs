using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobApplicationSystem.Migrations
{
    /// <inheritdoc />
    public partial class commit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Company", "Description", "Location", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, "Google", "Develop backend services", "USA", 0m, "Backend Developer" },
                    { 2, "Facebook", "Develop frontend UI", "UK", 0m, "Frontend Developer" },
                    { 3, "Amazon", "Analyze data", "Canada", 0m, "Data Scientist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
