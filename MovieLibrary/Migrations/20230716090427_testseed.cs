using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class testseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b205171-4d8a-4263-bd63-3bbe5a4ac676");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ecb3da6-6a4a-4b7a-81e7-360d8ac9f003");

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Accepted", "AppUserEmail", "AppUserId", "Budget", "Category", "Description", "MinimumAge", "PosterSource", "ProducerId", "Rating", "ReleaseDate", "Title", "TrailerUrl", "UsersRated" },
                values: new object[] { 1, false, "admin@admin.bg", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 100000000, "Action", "Tyler Rake, a fearless black market mercenary, embarks on the most deadly extraction of his career when he's enlisted to rescue the kidnapped son of an imprisoned international crime lord.", 18, "~/images/posters/extraction2020.jpg", 1, 0.0, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extraction", "Y274jZs5s7s", 0 });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "PostedTime", "Text" },
                values: new object[] { 1, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probvam sys Seed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b25ab95-74d0-4276-bf0c-205253600a61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4263ab6-e6ba-456e-8593-0a71d1cbf2ec");

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b205171-4d8a-4263-bd63-3bbe5a4ac676", "8dbd3d95-50fc-44ee-ab55-4f16e832be76", "Manager", "MANAGER" },
                    { "8ecb3da6-6a4a-4b7a-81e7-360d8ac9f003", "ad7f59ae-8efd-451d-a4dc-889da6aa5b89", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83bbe1d1-d6a1-487f-9e9b-1d3696310fd0", "AQAAAAEAACcQAAAAEAtUVID/dUY3RVaREgsostgru7LbAnaGop2Ab/p1C3xpxgbhxf0pd6kjgaoHq3ikxQ==", "1c021199-8926-4292-ab7e-53d0a7d5bb13" });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "PostedTime", "Text" },
                values: new object[] { 4, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Probvam sys Seed" });
        }
    }
}
