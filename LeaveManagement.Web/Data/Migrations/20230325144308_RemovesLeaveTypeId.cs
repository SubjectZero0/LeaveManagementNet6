using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class RemovesLeaveTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "140dc171-a02e-4a9a-8a2c-0e13e508c470");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "9491a644-7bb1-48a9-9e4b-42720c1af031");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f49fb68-0ca8-491a-9c67-2318784b8328", "AQAAAAEAACcQAAAAEEVb2MkmuHz404/7tfObQ979FsPtmCvXhyfLhvzcg/PHRQYnFziXHjmidx4O31qNwQ==", "7241c9a5-e7d3-441a-b881-b580c3be3172" });
        }
    }
}
