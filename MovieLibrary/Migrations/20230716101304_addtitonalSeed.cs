using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class addtitonalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "774f0df8-f23a-47a9-859c-a9a601a62b18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb9ef24-854c-40b4-9eeb-2d39d147f8d7");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "AppUserId", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 2, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Chris", "Male", "Hemsworth" },
                    { 3, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Golshifteh", "Female", "Farahani" },
                    { 4, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Adam", "Male", "Bessa" },
                    { 5, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Ryder", "Male", "Lerum" },
                    { 6, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Bryon", "Male", "Lerum" },
                    { 7, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Keanu", "Male", "Reeves" },
                    { 8, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Laurence", "Female", "Fishburne" },
                    { 9, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "George", "Male", "Georgiou" },
                    { 10, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Tim", "Male", "Robbins" },
                    { 11, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Morgan", "Male", "Freeman" },
                    { 12, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "Bob", "Male", "Guton" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3619fba3-c4f1-40fb-a55e-6511795cfa19", "c350acf4-5b35-4851-acec-c33168a80fd0", "Manager", "MANAGER" },
                    { "78d40ac6-e0dd-48be-83ee-45021caf491c", "fd07f3ad-724b-4df9-92cd-bba43b762cf7", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bfd3179-e93f-455c-9133-d5515c8e9d9b", "AQAAAAEAACcQAAAAEDgAtU8D7Ht2RrfDdHanwaX53AHCUK63fkttc1IoH7yIf+mvDYOC5GZapRVItxHvlg==", "dddbf736-d03c-4c93-8a57-8dd9da07e350" });

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 10, 13, 4, 160, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 10, 13, 4, 160, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 10, 13, 4, 160, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "PostedTime", "Text" },
                values: new object[] { 4, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 2, new DateTime(2023, 7, 16, 10, 13, 4, 160, DateTimeKind.Utc).AddTicks(8865), "I dont like it that much" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Sam Hargrave" },
                    { 10, "Chad Stahelski" },
                    { 11, "Frank Darabont" }
                });

            migrationBuilder.InsertData(
                table: "Actor_ActorAwards",
                columns: new[] { "ActorAwardId", "ActorId" },
                values: new object[] { 2, 11 });

            migrationBuilder.InsertData(
                table: "Actors_Movies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProducerId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProducerId",
                value: 9);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Accepted", "AppUserEmail", "AppUserId", "Budget", "Category", "Description", "MinimumAge", "PosterSource", "ProducerId", "Rating", "ReleaseDate", "Title", "TrailerUrl", "UsersRated" },
                values: new object[,]
                {
                    { 3, true, "admin@admin.bg", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 450000000, "Action", "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.", 18, "~/images/posters/johnwich4.jpeg", 10, 0.0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Wick: Chapter 4", "qEVUtrk8_B4", 0 },
                    { 4, true, "admin@admin.bg", "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 990000000, "Western", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", 16, "~/images/posters/shawshank.jpg", 11, 4.7000000000000002, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption", "6hB3S9bIaco", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Actors_Movies",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 4 },
                    { 11, 4 },
                    { 12, 4 }
                });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "PostedTime", "Text" },
                values: new object[] { 5, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 3, new DateTime(2023, 7, 16, 10, 13, 4, 160, DateTimeKind.Utc).AddTicks(8865), "Sadly its the last movie from the series" });

            migrationBuilder.InsertData(
                table: "Movie_MovieAwards",
                columns: new[] { "MovieAwardId", "MovieId" },
                values: new object[] { 3, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor_ActorAwards",
                keyColumns: new[] { "ActorAwardId", "ActorId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "Actors_Movies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3619fba3-c4f1-40fb-a55e-6511795cfa19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d40ac6-e0dd-48be-83ee-45021caf491c");

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movie_MovieAwards",
                keyColumns: new[] { "MovieAwardId", "MovieId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 11);

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
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostedTime",
                value: new DateTime(2023, 7, 16, 9, 37, 4, 674, DateTimeKind.Utc).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProducerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProducerId",
                value: 1);
        }
    }
}
