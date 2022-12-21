using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95f97acd-d694-44ae-af57-ca71a6c9c042", "f3360ecd-06be-49da-a584-572f233bd8b6", "Admin", "ADMIN" },
                    { "a77d45b9-c862-48c0-9b5c-921dc620741c", "07f0475e-e004-44ac-9f57-657a29464a82", "Manager", "MANAGER" },
                    { "d7488224-5270-4727-8197-db9227515c0d", "f425d0c4-8a62-4db2-b789-73f693b43865", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ee443c55-f31b-4145-aa46-33015f226ab5", 0, "6e17842b-631e-44e8-8eda-78c9752d0ef7", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN", "AQAAAAEAACcQAAAAEA4hHa7qSrkSrZqgJdX2ATiJb2xyuqoJiUgeQhv6t7uTtbPkpH5zOPI79a5GVYvg9w==", null, false, "dbb56803-6a93-4a10-bc3b-0dd18c747698", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f97acd-d694-44ae-af57-ca71a6c9c042");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a77d45b9-c862-48c0-9b5c-921dc620741c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7488224-5270-4727-8197-db9227515c0d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee443c55-f31b-4145-aa46-33015f226ab5");
        }
    }
}
