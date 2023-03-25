using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge7abc - 7641 - 473f - 907e - 15e88893788e",
                column: "ConcurrencyStamp",
                value: "eb6c0aa5-857a-458a-a03c-c9026ee1b0a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cge9abc - 6741 - 473f - 907e - 15e96893788e",
                column: "ConcurrencyStamp",
                value: "e8f493e1-9d0d-4cc2-8b8b-03f153854388");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dge9abc - 0000 - 471p - 907e - 15e96893788e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a2c7c4c-9515-473d-b783-f23e75d3e2df", "AQAAAAEAACcQAAAAEDybsroTYFYgP9V+aX28F8iv61OnBCi3jxy61SiG5wipspCiFV9WK62DOOS9aKnpZA==", "5c9c7b4e-2897-407f-aea2-2ff68637a6ac" });
        }
    }
}
