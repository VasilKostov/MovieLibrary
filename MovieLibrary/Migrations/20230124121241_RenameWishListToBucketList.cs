using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class RenameWishListToBucketList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8654b227-80a7-4d7f-9706-6fc10dd41c30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b4febd-426d-4408-bc9f-cf7a734357e8");

            migrationBuilder.CreateTable(
                name: "BucketLists",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketLists", x => new { x.AppUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_BucketLists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketLists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BucketLists_MovieId",
                table: "BucketLists",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BucketLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b332dd4a-f1c4-483b-abb0-7ec4452210db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb105f76-d4c3-4965-9f82-bed4af27f421");

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => new { x.AppUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_WishList_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8654b227-80a7-4d7f-9706-6fc10dd41c30", "053cee2e-f8a8-4543-aa0c-7850f9142b7f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89b4febd-426d-4408-bc9f-cf7a734357e8", "2700bec0-f76c-40dd-9fe0-b24a44ef3f28", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f221bfa5-8236-4bdc-840b-8ea19aaa1421", "AQAAAAEAACcQAAAAEGzouDJbt9KmhM0uBvxI7jLdJWIQQqlv7Y7PvDWvf+K2F/KYc1MZbou76R2QufPhGA==", "bc7c7f37-2482-469e-9d7a-462b33b5577d" });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_MovieId",
                table: "WishList",
                column: "MovieId");
        }
    }
}
