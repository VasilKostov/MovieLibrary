using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class moviecommentfkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_AspNetUsers_UserId",
                table: "MovieComment");

            migrationBuilder.DropIndex(
                name: "IX_MovieComment_UserId",
                table: "MovieComment");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MovieComment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "MovieComment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieComment_AppUserId",
                table: "MovieComment",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_AspNetUsers_AppUserId",
                table: "MovieComment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_AspNetUsers_AppUserId",
                table: "MovieComment");

            migrationBuilder.DropIndex(
                name: "IX_MovieComment_AppUserId",
                table: "MovieComment");

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

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MovieComment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MovieComment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieComment_UserId",
                table: "MovieComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_AspNetUsers_UserId",
                table: "MovieComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
