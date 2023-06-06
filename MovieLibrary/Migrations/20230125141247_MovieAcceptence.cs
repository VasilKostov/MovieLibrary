using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class MovieAcceptence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b332dd4a-f1c4-483b-abb0-7ec4452210db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb105f76-d4c3-4965-9f82-bed4af27f421");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b5e2a6-3fdc-436b-b0d6-505c9b9cf349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82fff4e1-5625-443f-99db-14e7ded72473");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b332dd4a-f1c4-483b-abb0-7ec4452210db", "7f82f932-ec9b-44e7-a627-14161845a3e5", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb105f76-d4c3-4965-9f82-bed4af27f421", "2b36dbb1-3524-48e2-9ffb-e806eea23725", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb9b13af-10e8-4bbc-9652-ce6040f4c2be", "AQAAAAEAACcQAAAAEGZO4q0SRS2WswvlThWr9KRWXT8LLlbO9Jfo6vMFtmqEOOdjBRhbIUvKPhLK2xod5Q==", "ea70c18d-1f61-4a7b-8a43-c5d55b3f2bd6" });
        }
    }
}
