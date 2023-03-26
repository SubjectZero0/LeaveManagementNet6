using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveAllocation_AddNumberOfDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "15930755-7123-4b3c-bc0f-7457e5ac309c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "1b4269d8-b32b-4680-93b1-f8dc4326ef6a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c06cbd4e-e05e-4d26-80c8-43b9ea240c66", "AQAAAAEAACcQAAAAEFr710VnB4E8D/GrkWYGD2ms1+EFV2sDcf+LMRSgR3bYXwJWimlgX5VAtIES8cqgFw==", "b496da27-7ae1-4386-a477-4aa94e6ccca4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "7975bd02-30fd-41fd-b661-f5191c09e18a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "ce7db108-fe7c-4ac4-87ef-d7b89e125e9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d0db105-a659-48c2-8868-e810109892ac", "AQAAAAEAACcQAAAAENq3roG9EXQ7TzQ7/v987Z5e5MfCkDfyxQ+24ucLnLHsbAvDbtqzaTly9NyqV+HNyA==", "05d5b31c-f7d9-43f5-b705-41f8a9829210" });
        }
    }
}
