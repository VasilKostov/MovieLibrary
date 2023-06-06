using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class profilepicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c8df256-a107-43a7-9050-de793142cb5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb3a051-0680-4c38-9109-7936dd0a97fd");

            migrationBuilder.AddColumn<byte[]>(
                name: "PictureSource",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "188ee988-b8de-412d-902d-760adc5b49d5", "a0718d5e-5020-437c-9d88-bfe29d9d616a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1b26b32-4515-4702-b476-1d373ac774c8", "fab41b6c-cd6c-4a5b-83ca-739f4056cf7e", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b811e4a-f676-4749-b040-f315794ba44d", "AQAAAAEAACcQAAAAEIWrA15HNVrKoZswrrGGM72LENmfCUEo/aoNtHUhoIu/82TjegAmq6utinVUHrInGQ==", "9cb4ceb8-1ced-4337-ad16-f1f6b8a8944b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188ee988-b8de-412d-902d-760adc5b49d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b26b32-4515-4702-b476-1d373ac774c8");

            migrationBuilder.DropColumn(
                name: "PictureSource",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c8df256-a107-43a7-9050-de793142cb5a", "71b155c0-1df6-4881-a7a8-bbc6201e0740", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcb3a051-0680-4c38-9109-7936dd0a97fd", "0ad41d0d-e334-4a89-b733-8b87b0b619ed", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7076a545-500d-4c14-9b7c-8a4e856e2582", "AQAAAAEAACcQAAAAEH5/TAnYCKreOobHTvR3cGgV/2fSw7CZeFP5+EgzmgdnopPKcSZAvwuz15qLo86lNg==", "8b575d55-2e03-4d8e-8b1c-1739e7b7f6cf" });
        }
    }
}
