using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class seedComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11d71840-876a-4b5b-aebe-d713d9c7d061");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e18568-cf27-49fa-bdda-08831928c110");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0707b619-a456-43c9-8381-9c0dfe3a99f1", "1d38bb1c-49c0-4c21-964e-b4b4784f76eb", "User", "USER" },
                    { "c8185840-eee4-4a1c-b094-056d6be8c554", "5b6e7124-fd2d-4956-bd90-0b290297c6e5", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3a03df-51a8-4087-8663-ab15bc5c2db4", "AQAAAAEAACcQAAAAEFYRv4lmkMAmSrYkiS9vy7rTPZX6tHW6JDt3BaLcR5yMRVAw2oARUaK53TcX11o+PA==", "a0ebac5a-7660-43de-b0f9-2717b7d44596" });

            migrationBuilder.InsertData(
                table: "MovieComments",
                columns: new[] { "Id", "AppUserId", "MovieId", "Text" },
                values: new object[] { 4, "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 1, "Probvam sys Seed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0707b619-a456-43c9-8381-9c0dfe3a99f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8185840-eee4-4a1c-b094-056d6be8c554");

            migrationBuilder.DeleteData(
                table: "MovieComments",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
