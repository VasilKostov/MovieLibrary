using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class linksbtweenMovieNActorWithAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "444e1128-4623-4620-97f6-0e094f29f8f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7fb6598-8f66-4883-a236-2b60119732d5");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Movies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Actors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c577550-ea71-4436-8637-0d34367be4cd", "8b50b0dd-348d-4239-86bd-70c514f5da63", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0ef75cd-ece0-4a07-838e-2e125f58d739", "1e9eb65d-478c-473a-9bec-7af84902fcbe", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54026215-8461-4202-a9de-a72ee7fbd55f", "AQAAAAEAACcQAAAAECnX4o12wgeGreaA3rhCmD+q6Ra2aUeoAI27lGhnN4QruwlRQNx2fPUlDx+db/6Kpw==", "5a9b78ae-0f38-495a-9763-592ef54b226b" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_AppUserId",
                table: "Actors",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_AspNetUsers_AppUserId",
                table: "Actors",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_AspNetUsers_AppUserId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_AppUserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_AppUserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Actors_AppUserId",
                table: "Actors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c577550-ea71-4436-8637-0d34367be4cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ef75cd-ece0-4a07-838e-2e125f58d739");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Actors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "444e1128-4623-4620-97f6-0e094f29f8f1", "f405e39e-7414-4ebc-8a7a-53c14038c8c6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7fb6598-8f66-4883-a236-2b60119732d5", "22312641-8184-43d7-bb78-5285c5a24002", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef3ef561-150d-4f30-be8a-1970921ba361", "AQAAAAEAACcQAAAAEMPrieZEuDZztHSH1ZspU7LsdpjKVjiZ7Ptw9Dn50/rrn8nDc4Qr5JQtY/GmaaIX7w==", "1cc6a9ff-327d-4e88-a536-4cc43b129762" });
        }
    }
}
