using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class AppUserAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2232925b-cfdd-401e-9c1f-265358b9afc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c560c5b-46d2-41a3-b339-910711d71119");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51feedfc-52fe-4626-9561-771940c66900", "5b9f01d3-5cf7-4813-ad74-f43bf54b9924", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2e622bb-9014-46e2-b34a-869f932538b6", "1d11d1ed-52bf-41da-b3a1-512eb4baa169", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cfd400f-44fb-4d6b-a986-39e3ee0676f1", "AQAAAAEAACcQAAAAEL8GjKLvFdo8rBmNm8p6huXA/Ql4HAViU1XXWXIxNoUlw61XdS3JDGbriyFJj4Mw2w==", "91462b85-0d3a-45f5-9ace-c2c0f2cbd997" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51feedfc-52fe-4626-9561-771940c66900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2e622bb-9014-46e2-b34a-869f932538b6");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2232925b-cfdd-401e-9c1f-265358b9afc6", "52bbeae3-3168-4df2-a3d9-e13fec4f4682", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c560c5b-46d2-41a3-b339-910711d71119", "eb422831-db91-41d9-9ea5-ebd309f84b4b", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41790b0d-3f2a-41f6-9095-41293ec451c5", "AQAAAAEAACcQAAAAEOev4B2z2zslXOpjxd3Jjv6aig9XPq8GWybYR1+dw8Rpa94L1SNjQxWK7I6p3gEO5w==", "8cd996eb-3432-4259-aa3d-ff8aa2535653" });
        }
    }
}
