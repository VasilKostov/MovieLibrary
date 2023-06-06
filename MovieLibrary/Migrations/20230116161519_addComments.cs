using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class addComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_AspNetUsers_AppUserId",
                table: "MovieComment");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComment_Movies_MovieId",
                table: "MovieComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieComment",
                table: "MovieComment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bf1bae-6b07-413c-997d-c815410f3902");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad37c2c-4d22-426a-bdd1-2c9286fbfc3a");

            migrationBuilder.RenameTable(
                name: "MovieComment",
                newName: "MovieComments");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComment_MovieId",
                table: "MovieComments",
                newName: "IX_MovieComments_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComment_AppUserId",
                table: "MovieComments",
                newName: "IX_MovieComments_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieComments",
                table: "MovieComments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11d71840-876a-4b5b-aebe-d713d9c7d061", "a8202e3f-258d-4630-8b9f-1a3c4ee66897", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71e18568-cf27-49fa-bdda-08831928c110", "ce42536c-bd76-449d-9084-006a77d50ed5", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc0f2470-6ad4-435f-a8a2-6f540b1fbef4", "AQAAAAEAACcQAAAAEAChlhMGfvUnwYhstZZGO5gtLCsJOlHgJdFZCm8m0ufNHnJ5ot+A3C2Cvn1G0phMcg==", "432c8a10-7454-4bd8-9d6a-dfcd076a58c4" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_AspNetUsers_AppUserId",
                table: "MovieComments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_AspNetUsers_AppUserId",
                table: "MovieComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieComments",
                table: "MovieComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11d71840-876a-4b5b-aebe-d713d9c7d061");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e18568-cf27-49fa-bdda-08831928c110");

            migrationBuilder.RenameTable(
                name: "MovieComments",
                newName: "MovieComment");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComment",
                newName: "IX_MovieComment_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieComments_AppUserId",
                table: "MovieComment",
                newName: "IX_MovieComment_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieComment",
                table: "MovieComment",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09bf1bae-6b07-413c-997d-c815410f3902", "df4cb114-29ed-498f-a406-43ca16e2a1ec", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dad37c2c-4d22-426a-bdd1-2c9286fbfc3a", "1c04cf22-1272-4da5-93f8-b03237d3c022", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59451ee6-08a5-4b87-8f1a-edd7a363f24c", "AQAAAAEAACcQAAAAENyhPGdVohGpRMz2NIm1+2zJO0JHR3/bv/N9PiNd2de9lhB2MGbdCN7qPdbkhL5oQA==", "1487bc78-903e-48bf-9599-8edf21cceb3a" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_AspNetUsers_AppUserId",
                table: "MovieComment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComment_Movies_MovieId",
                table: "MovieComment",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
