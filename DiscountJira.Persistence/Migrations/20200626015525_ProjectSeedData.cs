using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountJira.Persistence.Migrations
{
    public partial class ProjectSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "Version", "isArchived", "isDeleted" },
                values: new object[] { 1, null, "value 101", 1.0, false, false });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "Version", "isArchived", "isDeleted" },
                values: new object[] { 2, null, "value 102", 1.0, false, false });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "Version", "isArchived", "isDeleted" },
                values: new object[] { 3, null, "value 103", 1.0, false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
