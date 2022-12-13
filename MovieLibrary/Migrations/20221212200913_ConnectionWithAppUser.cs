using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class ConnectionWithAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorAwards_Actor_ActorId",
                table: "ActorAwards");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAwards_Movies_MovieId",
                table: "MovieAwards");

            migrationBuilder.DropTable(
                name: "ActorsMovies");

            migrationBuilder.DropTable(
                name: "MovieComments");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropIndex(
                name: "IX_MovieAwards_MovieId",
                table: "MovieAwards");

            migrationBuilder.DropIndex(
                name: "IX_ActorAwards_ActorId",
                table: "ActorAwards");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieAwards");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorAwards");

            migrationBuilder.RenameColumn(
                name: "UserRates",
                table: "Movies",
                newName: "UsersRated");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumAge",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AwardName",
                table: "MovieAwards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AwardName",
                table: "ActorAwards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_MovieAward",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieAwardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_MovieAward", x => new { x.MovieAwardId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Movie_MovieAward_MovieAwards_MovieAwardId",
                        column: x => x.MovieAwardId,
                        principalTable: "MovieAwards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_MovieAward_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieComment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieComment_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actor_ActorAwards",
                columns: table => new
                {
                    ActorAwardId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor_ActorAwards", x => new { x.ActorId, x.ActorAwardId });
                    table.ForeignKey(
                        name: "FK_Actor_ActorAwards_ActorAwards_ActorAwardId",
                        column: x => x.ActorAwardId,
                        principalTable: "ActorAwards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actor_ActorAwards_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actors_Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors_Movies", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoriesId",
                table: "Movies",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_ActorAwards_ActorAwardId",
                table: "Actor_ActorAwards",
                column: "ActorAwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Movies_MovieId",
                table: "Actors_Movies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_MovieAward_MovieId",
                table: "Movie_MovieAward",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComment_MovieId",
                table: "MovieComment",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComment_UserId",
                table: "MovieComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieCategory_CategoriesId",
                table: "Movies",
                column: "CategoriesId",
                principalTable: "MovieCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieCategory_CategoriesId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Actor_ActorAwards");

            migrationBuilder.DropTable(
                name: "Actors_Movies");

            migrationBuilder.DropTable(
                name: "Movie_MovieAward");

            migrationBuilder.DropTable(
                name: "MovieCategory");

            migrationBuilder.DropTable(
                name: "MovieComment");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoriesId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MinimumAge",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AwardName",
                table: "MovieAwards");

            migrationBuilder.DropColumn(
                name: "AwardName",
                table: "ActorAwards");

            migrationBuilder.RenameColumn(
                name: "UsersRated",
                table: "Movies",
                newName: "UserRates");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "MovieAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "ActorAwards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieComments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorsMovies",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsMovies", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieAwards_MovieId",
                table: "MovieAwards",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorAwards_ActorId",
                table: "ActorAwards",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorsMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorAwards_Actor_ActorId",
                table: "ActorAwards",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAwards_Movies_MovieId",
                table: "MovieAwards",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
