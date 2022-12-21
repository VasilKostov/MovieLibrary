using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class adminrolefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "Admin", "ADMIN" },
                    { "7ab07d6e-87d0-4ab3-8639-1c2130e69c30", "2f31ea14-83b6-43e1-8403-6947684ca884", "Manager", "MANAGER" },
                    { "e77f804f-4d91-4d3b-8cc9-a4455cee03ad", "b33b4a29-1678-428f-a5c8-e1cd7da179f1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, "800125bb-0a8b-44fb-b720-948f6d970d49", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN", "AQAAAAEAACcQAAAAEC7xHMCJkIA4J8Ag+XXnZC1fjDFL0GnQW5r1iZpccW1qWZnGagbvl0TF32MWyIyTmQ==", null, false, "835c1383-b4fe-48cd-a54f-bfdea09e0dc8", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab07d6e-87d0-4ab3-8639-1c2130e69c30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77f804f-4d91-4d3b-8cc9-a4455cee03ad");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6");

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
    }
}
