using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveAllocation_AddNumberOfDays2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "c9bfbaa7-a7c7-4345-8a53-b94523fc79c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "ac974738-dbe2-43d7-9792-12962df5301a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb6df796-4875-4370-b5e1-17608a3cd71e", "AQAAAAEAACcQAAAAEEE6J4XIsFm4SDD6PJxOjTWdtlTZ8lzg/LdP5cLEJikW0R1cT7WsGUE6hJ9ON0VSGA==", "824cf035-1efe-4357-ab07-ed1f5ad3cf5f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
