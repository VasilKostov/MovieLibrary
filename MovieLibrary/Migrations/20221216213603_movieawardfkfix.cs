using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class movieawardfkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "097edfe2-0ce7-4f20-ab4d-6f1c79b8e4a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32dbb317-e00d-47be-9765-d86f4619864c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a4e10bb-cd10-492b-ae3f-6b420094a4b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1967deed-f332-443a-809d-d0bc0b8f2534");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "753cc253-cc97-460a-888e-2a8ccbc8886c", "ab3adc13-2273-469c-adcf-4ee250c0353c", "User", "USER" },
                    { "93644baf-2787-4575-989e-bb61bd5d797f", "ca14b966-1e3b-49fb-b99d-647b213a2129", "Manager", "MANAGER" },
                    { "ea4c6946-b526-409c-b8f6-aac80834f0ae", "5d31883d-c46f-41f4-b459-2e33b6b9c07c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d3963a78-eab8-455c-8ab5-ebab80914a61", 0, "356d391c-9b01-42d7-8686-da5b1b76f78d", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN", "AQAAAAEAACcQAAAAECg4uhYH7FWnEaPrH4jWiWtugAAXhojTl1ILB2a2xHW6EADfdNKciIur20lIu55t9g==", null, false, "bb3a460e-2db3-44a5-88b9-e035bdb6c9fd", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "753cc253-cc97-460a-888e-2a8ccbc8886c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93644baf-2787-4575-989e-bb61bd5d797f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea4c6946-b526-409c-b8f6-aac80834f0ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3963a78-eab8-455c-8ab5-ebab80914a61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "097edfe2-0ce7-4f20-ab4d-6f1c79b8e4a3", "507fda1f-ce8e-4199-99ee-a9a39bb80fb1", "Manager", "MANAGER" },
                    { "32dbb317-e00d-47be-9765-d86f4619864c", "dfa5e7c3-c63b-4907-bb7d-86cb18236726", "User", "USER" },
                    { "3a4e10bb-cd10-492b-ae3f-6b420094a4b2", "991f687a-3bbd-4584-b2af-6362ec5ad880", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1967deed-f332-443a-809d-d0bc0b8f2534", 0, "854398ae-c7e7-47b1-9033-5d14b45c9c89", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN", "AQAAAAEAACcQAAAAENS8S/CkY3mp4TA+oUnVEP9xqjlmRsvPKnwd+t70UyqafqUUCvRQpqMORB+sFOyPTw==", null, false, "b755a740-3219-4c11-b980-c51ef00de3a2", false, "Admin" });
        }
    }
}
