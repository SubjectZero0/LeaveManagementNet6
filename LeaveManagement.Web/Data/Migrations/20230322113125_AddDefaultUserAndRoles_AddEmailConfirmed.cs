using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddDefaultUserAndRoles_AddEmailConfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "afc14993-7ad5-4e5b-897b-ed857c3abf17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "5ca69379-10da-40f3-96aa-ae3f3ff0fea8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f749a4dd-6157-432d-830c-a5ed09c163f6", true, "AQAAAAEAACcQAAAAELZQEl1M30o7hT+UGdmbuqyk7n0JnyNR7FbexWLsVf84ywqXL/XyzYr0d7bBi0qLgA==", "c5081541-a763-41a8-8334-032751aee509" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "aa8b0b60-3be0-4cd7-8b29-826bf9dc02d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "1ab4ca35-326e-4c18-a6c3-f57130d7c58f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08f6cf67-d255-4713-a823-0ad425d0c47f", false, "AQAAAAEAACcQAAAAEK/M7gG84MwxGR67TPcQYJ8mm6GRtrWfqTne9mNSo+85vu/S8NrKGVlCbKLVNRgy1g==", "ab8d1130-9b10-4140-87be-eea6af44a21f" });
        }
    }
}
