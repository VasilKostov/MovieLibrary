using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class actorFullNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02622627-49be-4ea1-b1ec-1247bb833fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c7c47c-f168-4269-bbf4-54a178f25960");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Female");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f3f12446-5f60-4e62-97ad-f8505a9f3134", "55d0d2fa-5afc-4fa2-8525-ea06955b63ff", "User", "USER" },
                    { "f96ce4e2-58b0-4e15-999f-ce852ff239be", "1b36b9ec-723e-45c7-ac8c-42afb1f15fa6", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4f4fde-a041-4184-bbd4-9a1e3c58819b", "AQAAAAEAACcQAAAAEMj1Kb5qpHXN1DIysQEkKgR7oNcuggusOwCx1U+cuDo5wKmfYlaebXcZMfkikEkdpQ==", "0f0d2c82-0f31-46d1-b452-18e59bd05d21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3f12446-5f60-4e62-97ad-f8505a9f3134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96ce4e2-58b0-4e15-999f-ce852ff239be");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Male");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02622627-49be-4ea1-b1ec-1247bb833fb8", "6726fe04-b674-406c-8a97-c91f43e1d58c", "Manager", "MANAGER" },
                    { "e5c7c47c-f168-4269-bbf4-54a178f25960", "2bdcc7d8-41fd-4be9-8054-832de102046d", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ae10ddb-52f5-467f-a78b-dbd398074e8b", "AQAAAAEAACcQAAAAECAUM/RgGOXAxIuTcPt+HFstZQbUaYCnYB6gMhlHwJo7v+7NtIRMNShuH9aeXFBftg==", "618f42df-f74a-4377-b29e-92aa05b5564f" });
        }
    }
}
