using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cge7abc - 7641 - 473f - 907e - 15e88893788e", "16dc44db-15b9-42df-bb21-faa7873fcce8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cge9abc - 6741 - 473f - 907e - 15e96893788e", "bb5261e2-5fe4-4161-a243-d88da068dd2c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3dge9abc - 0000 - 471p - 907e - 15e96893788e", 0, "89b284a8-db6d-42eb-aaea-ecdf0a7e0ef8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", false, "Admin", "Adminakis", false, null, "ADMIN@ADMIN.COM", null, "AQAAAAEAACcQAAAAEIGk5ilnYoY4sNS6buXF7JRF6irCWtixWHGYSW56iAPLHFaOmofIxmNBQkGpio/HxA==", null, false, "6adfc705-7c8d-4497-a6ba-3b4b32fc321c", "123456789123456", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4cge9abc - 6741 - 473f - 907e - 15e96893788e", "3dge9abc - 0000 - 471p - 907e - 15e96893788e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4cge9abc - 6741 - 473f - 907e - 15e96893788e", "3dge9abc - 0000 - 471p - 907e - 15e96893788e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e");
        }
    }
}
