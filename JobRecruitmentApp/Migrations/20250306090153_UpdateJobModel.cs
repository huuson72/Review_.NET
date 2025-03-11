using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobRecruitmentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Job_Title",
                table: "Jobs",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "Job_Title");
        }
    }
}
