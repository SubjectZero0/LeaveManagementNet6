using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddDefaultUserAndRoles_AddUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "08f6cf67-d255-4713-a823-0ad425d0c47f", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEK/M7gG84MwxGR67TPcQYJ8mm6GRtrWfqTne9mNSo+85vu/S8NrKGVlCbKLVNRgy1g==", "ab8d1130-9b10-4140-87be-eea6af44a21f", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "16dc44db-15b9-42df-bb21-faa7873fcce8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "bb5261e2-5fe4-4161-a243-d88da068dd2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "89b284a8-db6d-42eb-aaea-ecdf0a7e0ef8", null, "AQAAAAEAACcQAAAAEIGk5ilnYoY4sNS6buXF7JRF6irCWtixWHGYSW56iAPLHFaOmofIxmNBQkGpio/HxA==", "6adfc705-7c8d-4497-a6ba-3b4b32fc321c", null });
        }
    }
}
