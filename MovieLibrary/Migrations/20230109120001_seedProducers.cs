using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class seedProducers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fe6777e-a0c1-450a-b71d-ae39fd7c20e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751b60ef-a2e6-4aeb-ae27-0f7cd13c2174");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2232925b-cfdd-401e-9c1f-265358b9afc6", "52bbeae3-3168-4df2-a3d9-e13fec4f4682", "User", "USER" },
                    { "4c560c5b-46d2-41a3-b339-910711d71119", "eb422831-db91-41d9-9ea5-ebd309f84b4b", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41790b0d-3f2a-41f6-9095-41293ec451c5", "AQAAAAEAACcQAAAAEOev4B2z2zslXOpjxd3Jjv6aig9XPq8GWybYR1+dw8Rpa94L1SNjQxWK7I6p3gEO5w==", "8cd996eb-3432-4259-aa3d-ff8aa2535653" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Michael Mann" },
                    { 3, "Steven Spielberg" },
                    { 4, "Jerry Bruckheimer" },
                    { 5, "Spike LeeSpike Lee" },
                    { 6, "Irwin Winkler" },
                    { 7, "Dana Brunetti" },
                    { 8, "Kathleen Kennedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2232925b-cfdd-401e-9c1f-265358b9afc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c560c5b-46d2-41a3-b339-910711d71119");

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 8);

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
    }
}
