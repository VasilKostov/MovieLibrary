using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class addAppUserEmailToTableMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3f12446-5f60-4e62-97ad-f8505a9f3134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96ce4e2-58b0-4e15-999f-ce852ff239be");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82629bea-0600-4909-b98f-57d11662f1e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f874cfe8-fcb2-4d27-bb25-415fa79a7527");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3f12446-5f60-4e62-97ad-f8505a9f3134", "55d0d2fa-5afc-4fa2-8525-ea06955b63ff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f96ce4e2-58b0-4e15-999f-ce852ff239be", "1b36b9ec-723e-45c7-ac8c-42afb1f15fa6", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4f4fde-a041-4184-bbd4-9a1e3c58819b", "AQAAAAEAACcQAAAAEMj1Kb5qpHXN1DIysQEkKgR7oNcuggusOwCx1U+cuDo5wKmfYlaebXcZMfkikEkdpQ==", "0f0d2c82-0f31-46d1-b452-18e59bd05d21" });
        }
    }
}
