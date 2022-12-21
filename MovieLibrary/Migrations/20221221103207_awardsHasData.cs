using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class awardsHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3574fa-d8d6-4bd4-a2c1-a95d348a568b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b2c231-e45d-4673-9763-6126c0e593e5");

            migrationBuilder.RenameColumn(
                name: "AwardName",
                table: "MovieAwards",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AwardName",
                table: "ActorAwards",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Budget",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "ActorAwards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Best Actress" },
                    { 2, "Screen Actors Guild Award" },
                    { 3, "Academy Award (Oscar)" },
                    { 4, "European Film Award" },
                    { 5, "Best Actor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a8b2193-3356-4f44-b552-316690acd3e6", "f1b6d08a-6ee2-460d-ae84-5804816f966c", "Manager", "MANAGER" },
                    { "e1670c99-ff74-4629-9842-b899171b4583", "5c045050-e17e-4752-bcae-60c1a75fe6cb", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "826c2aa3-479b-435f-b0b5-ae74e6e17c0a", "AQAAAAEAACcQAAAAEBBvtK+NDd3YlHcWSlDTLTcVLLSDC+OdTVFcrZCEpRnvIbVHqaiNgiVJkZpL/1PqUg==", "86cc0915-9f5e-4f4c-baf3-ba80bb48664a" });

            migrationBuilder.InsertData(
                table: "MovieAwards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Emmy" },
                    { 2, "Golden Globe" },
                    { 3, "Academy Award (Oscar)" },
                    { 4, "European Film Award" },
                    { 5, "British Academy Film Award" },
                    { 6, "Filmfare Award" },
                    { 7, "Critics' Choice Movie" },
                    { 8, "Best Feature Film" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorAwards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActorAwards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActorAwards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActorAwards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActorAwards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a8b2193-3356-4f44-b552-316690acd3e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1670c99-ff74-4629-9842-b899171b4583");

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieAwards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MovieAwards",
                newName: "AwardName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ActorAwards",
                newName: "AwardName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Budget",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b3574fa-d8d6-4bd4-a2c1-a95d348a568b", "368d1805-a015-4010-a4b1-e9c9237c4a4a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0b2c231-e45d-4673-9763-6126c0e593e5", "610d1a54-bb57-4624-9ff2-10b71c170dd5", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02a68922-bae6-4441-a157-95904c9df2fa", "AQAAAAEAACcQAAAAECmwlQ4nUP6riTcxHnhKCsu9iQrKcdEGwXFN+5Kn9CLpj6mNrP8fE8ljOedvOFILyQ==", "8ae8cb53-0bed-49c2-81bb-07cd8ad30daf" });
        }
    }
}
