using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class moviecategoryenum2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4e7ce7b-82d1-45c1-bb06-dfc83174d367");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eba814e4-ebac-47d4-8450-0346a8d3de73");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a4e7ce7b-82d1-45c1-bb06-dfc83174d367", "0b3ff91e-489c-47aa-8593-464ca3993ab4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eba814e4-ebac-47d4-8450-0346a8d3de73", "3f32be50-97a8-498a-acb0-18c532ebc85c", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0647977c-89e9-4cb5-9a9d-f417be3b08d3", "AQAAAAEAACcQAAAAEPZdIc6eWSFkr11eAp67zBTd7UkhwrvtO7cb45OnZqHQoFSsBAiX1oXAP2ML9b9mKQ==", "7c8ec5a0-a517-4d97-8001-11998604bf67" });
        }
    }
}
