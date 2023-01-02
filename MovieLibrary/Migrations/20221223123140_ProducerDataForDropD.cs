using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class ProducerDataForDropD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "77513a54-3fd6-4545-a880-4c78bf885dab", "149bdfc9-f683-49bc-b27a-3f2dfbf23c15", "Manager", "MANAGER" },
                    { "97b1fd47-a32d-461c-992e-ccdacf2a29a1", "f09e71d5-63ad-4f7f-b505-0ed46c120080", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82326595-94f6-422c-a63c-6ebed9871132", "AQAAAAEAACcQAAAAEL3esY89+dE8JvSdjsoDiM46YLTVS4dOacTDSduTEmokyUEos4mSEI08x+RK42dU3g==", "817035d2-8fe2-40d9-a8ad-883bd3c3d821" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Quentin Tarantino" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77513a54-3fd6-4545-a880-4c78bf885dab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97b1fd47-a32d-461c-992e-ccdacf2a29a1");

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
