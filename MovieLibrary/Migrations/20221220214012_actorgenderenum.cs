using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class actorgenderenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b80091c6-e26b-439d-8dad-1277f9f62ce5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4004d56-6f46-46f5-afc6-0a921f51e257");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b3574fa-d8d6-4bd4-a2c1-a95d348a568b", "368d1805-a015-4010-a4b1-e9c9237c4a4a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0b2c231-e45d-4673-9763-6126c0e593e5", "610d1a54-bb57-4624-9ff2-10b71c170dd5", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02a68922-bae6-4441-a157-95904c9df2fa", "AQAAAAEAACcQAAAAECmwlQ4nUP6riTcxHnhKCsu9iQrKcdEGwXFN+5Kn9CLpj6mNrP8fE8ljOedvOFILyQ==", "8ae8cb53-0bed-49c2-81bb-07cd8ad30daf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3574fa-d8d6-4bd4-a2c1-a95d348a568b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b2c231-e45d-4673-9763-6126c0e593e5");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b80091c6-e26b-439d-8dad-1277f9f62ce5", "f73ef9f9-22a3-4d84-95ac-7c46d4fe96dd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4004d56-6f46-46f5-afc6-0a921f51e257", "f92966c5-f1e8-4e6c-9507-64c0e7645d1b", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbacf255-9d65-4a10-90bc-9a9870e3b9ba", "AQAAAAEAACcQAAAAEMHJ/k/pqUTJ92bZDLmyE4bPS/fEvgXdyJ4dRHUc8qQW8eiWNchzCPkpR+T7GWpM+Q==", "9b5ecd74-017e-4d1f-b7c0-8ac78a8ebed4" });
        }
    }
}
