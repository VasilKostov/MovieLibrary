using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class addAppUserEmailToTableMovie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82629bea-0600-4909-b98f-57d11662f1e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f874cfe8-fcb2-4d27-bb25-415fa79a7527");

            migrationBuilder.AddColumn<string>(
                name: "AppUserEmail",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fe6777e-a0c1-450a-b71d-ae39fd7c20e3", "628c123d-6581-422f-949d-f63a819d8fab", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "751b60ef-a2e6-4aeb-ae27-0f7cd13c2174", "5bf3e5e7-b57f-4916-b452-8b182f325edd", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3ef66c6-5180-4577-ae2a-e44e3cc2f29d", "AQAAAAEAACcQAAAAEJh9i/Czx2G3O4jHx4X7hha3G00Lu7G5og+nzsuxdYNeJqO0LnC2rbowEnS8Wt5B2Q==", "94792170-56b0-4acf-8adc-b7357a4e1894" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fe6777e-a0c1-450a-b71d-ae39fd7c20e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751b60ef-a2e6-4aeb-ae27-0f7cd13c2174");

            migrationBuilder.DropColumn(
                name: "AppUserEmail",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82629bea-0600-4909-b98f-57d11662f1e5", "704a559e-3f58-4cb8-a2ee-3fa63caa8cbc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f874cfe8-fcb2-4d27-bb25-415fa79a7527", "a8de8456-007f-4a59-8402-eaa620aeb341", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "729387df-2013-4f48-9813-cd33e5c9bc1f", "AQAAAAEAACcQAAAAEHTnMcf46yg+GfMD0QUOk4Srbq0HOXaBkbYRXWpFknxUzN3ExX+ADP8yFL6Ul9qBtQ==", "3c64ae06-1c5e-414d-a119-6ecdcae0ff9e" });
        }
    }
}
