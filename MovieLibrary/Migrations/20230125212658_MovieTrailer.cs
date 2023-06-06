using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class MovieTrailer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b5e2a6-3fdc-436b-b0d6-505c9b9cf349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82fff4e1-5625-443f-99db-14e7ded72473");

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b205171-4d8a-4263-bd63-3bbe5a4ac676", "8dbd3d95-50fc-44ee-ab55-4f16e832be76", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ecb3da6-6a4a-4b7a-81e7-360d8ac9f003", "ad7f59ae-8efd-451d-a4dc-889da6aa5b89", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83bbe1d1-d6a1-487f-9e9b-1d3696310fd0", "AQAAAAEAACcQAAAAEAtUVID/dUY3RVaREgsostgru7LbAnaGop2Ab/p1C3xpxgbhxf0pd6kjgaoHq3ikxQ==", "1c021199-8926-4292-ab7e-53d0a7d5bb13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b205171-4d8a-4263-bd63-3bbe5a4ac676");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ecb3da6-6a4a-4b7a-81e7-360d8ac9f003");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62b5e2a6-3fdc-436b-b0d6-505c9b9cf349", "f5d04aae-d117-4a3a-98bf-ebfa3b494f69", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82fff4e1-5625-443f-99db-14e7ded72473", "a6788ccd-4945-4a7e-8e12-1217fc0f38c0", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e2a20b7-e1f3-4195-b7d2-86e9165b36a6", "AQAAAAEAACcQAAAAEDRnznUdr85JwjIAUqB3Pj/VCc/Nlnbmh7IB4ykusif6TrZLr0HKqwswrM+Lk3CB2g==", "73f8b133-3acc-489a-a8c1-2d029441b348" });
        }
    }
}
