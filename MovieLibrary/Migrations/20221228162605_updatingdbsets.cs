using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class updatingdbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieAward_MovieAwards_MovieAwardId",
                table: "Movie_MovieAward");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieAward_Movies_MovieId",
                table: "Movie_MovieAward");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_MovieAward",
                table: "Movie_MovieAward");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77513a54-3fd6-4545-a880-4c78bf885dab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97b1fd47-a32d-461c-992e-ccdacf2a29a1");

            migrationBuilder.RenameTable(
                name: "Movie_MovieAward",
                newName: "Movie_MovieAwards");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_MovieAward_MovieId",
                table: "Movie_MovieAwards",
                newName: "IX_Movie_MovieAwards_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_MovieAwards",
                table: "Movie_MovieAwards",
                columns: new[] { "MovieAwardId", "MovieId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieAwards_MovieAwards_MovieAwardId",
                table: "Movie_MovieAwards",
                column: "MovieAwardId",
                principalTable: "MovieAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieAwards_Movies_MovieId",
                table: "Movie_MovieAwards",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieAwards_MovieAwards_MovieAwardId",
                table: "Movie_MovieAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieAwards_Movies_MovieId",
                table: "Movie_MovieAwards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_MovieAwards",
                table: "Movie_MovieAwards");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f1fa33c-f882-4253-a225-3da102c5dd31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90e0c484-df70-45db-80e7-cad466868a0e");

            migrationBuilder.RenameTable(
                name: "Movie_MovieAwards",
                newName: "Movie_MovieAward");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_MovieAwards_MovieId",
                table: "Movie_MovieAward",
                newName: "IX_Movie_MovieAward_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_MovieAward",
                table: "Movie_MovieAward",
                columns: new[] { "MovieAwardId", "MovieId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77513a54-3fd6-4545-a880-4c78bf885dab", "149bdfc9-f683-49bc-b27a-3f2dfbf23c15", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97b1fd47-a32d-461c-992e-ccdacf2a29a1", "f09e71d5-63ad-4f7f-b505-0ed46c120080", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82326595-94f6-422c-a63c-6ebed9871132", "AQAAAAEAACcQAAAAEL3esY89+dE8JvSdjsoDiM46YLTVS4dOacTDSduTEmokyUEos4mSEI08x+RK42dU3g==", "817035d2-8fe2-40d9-a8ad-883bd3c3d821" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieAward_MovieAwards_MovieAwardId",
                table: "Movie_MovieAward",
                column: "MovieAwardId",
                principalTable: "MovieAwards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieAward_Movies_MovieId",
                table: "Movie_MovieAward",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
