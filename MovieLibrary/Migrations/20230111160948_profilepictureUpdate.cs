using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class profilepictureUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188ee988-b8de-412d-902d-760adc5b49d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b26b32-4515-4702-b476-1d373ac774c8");

            migrationBuilder.AlterColumn<string>(
                name: "PictureSource",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10e5c19f-c0e0-43ae-ad99-6ef9400537ba", "d031054b-4930-499a-bc5b-e47c2a9b237a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16646028-57ac-4432-b1d7-e9779af30e37", "1a417aa8-63f9-4d87-a20d-8313d1f9cdd5", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dba89085-2971-4834-9d48-25b1522ab2f8", "AQAAAAEAACcQAAAAEC44b1Cs5MjvZ8Lu3fFVMBBHCz037BW11Wenp4NB3JcmzHRBMA7h9m4PMQ0TG1EeJw==", "3de38aaf-e720-448e-8117-6069f41ec122" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10e5c19f-c0e0-43ae-ad99-6ef9400537ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16646028-57ac-4432-b1d7-e9779af30e37");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureSource",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
