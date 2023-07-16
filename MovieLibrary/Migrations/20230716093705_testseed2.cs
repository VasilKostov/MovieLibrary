using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class testseed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b25ab95-74d0-4276-bf0c-205253600a61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4263ab6-e6ba-456e-8593-0a71d1cbf2ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "774f0df8-f23a-47a9-859c-a9a601a62b18", "d82ca38d-732c-4bad-b425-1c347ab964ed", "Manager", "MANAGER" },
                    { "7fb9ef24-854c-40b4-9eeb-2d39d147f8d7", "6d431cf2-7574-48e5-9d86-cdb4ff35755d", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1647dee7-b28f-448a-b437-f5c3e508657a", "AQAAAAEAACcQAAAAECCO1J/xHcbNb0Wm/N/3M1TBbLt6qynSt1zGOFgykapXVHqFAzDe+ZiRbSdpnFBPmQ==", "81e11253-e86f-42cf-8692-1a64c8d18798" });

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostedTime", "Text" },
                values: new object[] { new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8884), "Very good movie!" });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "PostedTime", "Text" },
                values: new object[,]
                {
                    { 2, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 1, new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8915), "I can agree too" },
                    { 3, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 1, new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8925), "I want to watch the next one" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Accepted", "ReleaseDate", "TrailerUrl" },
                values: new object[] { true, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L6P3nI6VnlY" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Accepted", "AppUserEmail", "AppUserId", "Budget", "Category", "Description", "MinimumAge", "PosterSource", "ProducerId", "Rating", "ReleaseDate", "Title", "TrailerUrl", "UsersRated" },
                values: new object[] { 2, true, "admin@admin.bg", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 300000000, "Action", "After barely surviving his grievous wounds from his mission in Dhaka, Bangladesh, Tyler Rake is back, and his team is ready to take on their next mission.", 18, "~/images/posters/extraction2023.jpg", 1, 0.0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extraction 2", "Y274jZs5s7s", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "774f0df8-f23a-47a9-859c-a9a601a62b18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb9ef24-854c-40b4-9eeb-2d39d147f8d7");

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b25ab95-74d0-4276-bf0c-205253600a61", "87c2f383-564b-4b6b-b288-30d5ba84a174", "Manager", "MANAGER" },
                    { "d4263ab6-e6ba-456e-8593-0a71d1cbf2ec", "02b577cd-323a-4cda-97f1-8f27e19b9a28", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94e2e6df-68d6-47c2-86a2-4d71f80580a4", "AQAAAAEAACcQAAAAEG1yBSqob+ks+4j4hlIzadH9431KcW/PuPW0r+b/edj2ifbme/8sbva6wOhvG7glZw==", "9c1787dc-a82b-4de4-9abb-1bd717e072cc" });

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PostedTime", "Text" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probvam sys Seed" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Accepted", "ReleaseDate", "TrailerUrl" },
                values: new object[] { false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Y274jZs5s7s" });
        }
    }
}
