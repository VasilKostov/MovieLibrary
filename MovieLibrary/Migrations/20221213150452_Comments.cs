using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieCategory_CategoriesId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Movies",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoriesId",
                table: "Movies",
                newName: "IX_Movies_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieCategory_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "MovieCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieCategory_CategoryId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Movies",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                newName: "IX_Movies_CategoriesId");

            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                table: "Actors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieCategory_CategoriesId",
                table: "Movies",
                column: "CategoriesId",
                principalTable: "MovieCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
