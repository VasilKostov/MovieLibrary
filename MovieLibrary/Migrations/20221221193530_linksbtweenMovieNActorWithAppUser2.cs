using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class linksbtweenMovieNActorWithAppUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c577550-ea71-4436-8637-0d34367be4cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ef75cd-ece0-4a07-838e-2e125f58d739");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e33c65e-d62c-40c5-8d8a-1bb3d63d1e66", "78e1d561-63b6-4ac4-948c-47850ab106a7", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cebfdf95-2f28-47c6-b56a-c98c2f5487a2", "3bfdca57-08c7-4c7c-a798-1ba0728c1a10", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "661d64a1-7db4-4fb7-a564-bc6c73aad6d6", "AQAAAAEAACcQAAAAEKCBP6bJDmgOGncMh97+LEpkiZyz0L5Zgnq4Pi8667984CG+TT+xbXOeH4Q8z8LOmQ==", "fbcf125e-69fd-4832-9387-5b54764a6ea2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e33c65e-d62c-40c5-8d8a-1bb3d63d1e66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cebfdf95-2f28-47c6-b56a-c98c2f5487a2");

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
        }
    }
}
