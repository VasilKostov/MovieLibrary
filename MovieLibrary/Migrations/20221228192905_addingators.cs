using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class addingators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f1fa33c-f882-4253-a225-3da102c5dd31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90e0c484-df70-45db-80e7-cad466868a0e");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "AppUserId", "FirstName", "Gender", "LastName" },
                values: new object[] { 1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Margot", "Male", "Robbie" });

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

            migrationBuilder.InsertData(
                table: "Actor_ActorAwards",
                columns: new[] { "ActorAwardId", "ActorId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor_ActorAwards",
                keyColumns: new[] { "ActorAwardId", "ActorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02622627-49be-4ea1-b1ec-1247bb833fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c7c47c-f168-4269-bbf4-54a178f25960");

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f1fa33c-f882-4253-a225-3da102c5dd31", "54e7a610-e30e-4280-ba83-f630955e2a17", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90e0c484-df70-45db-80e7-cad466868a0e", "6ade7be7-5e6e-4613-9929-2b0dda1e514a", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4973ce14-8d76-4f4e-af78-87c869c654d5", "AQAAAAEAACcQAAAAEOMYybmCWUpYxxKuuTg5M0EXu/KqQdBuwJ5AOdnCwVKMM+Td2lNDZ0lliQ6iG9j6iA==", "14dc39a7-cade-4dbe-ba3e-cb498ee89ac1" });
        }
    }
}
