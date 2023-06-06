using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class moviePoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10e5c19f-c0e0-43ae-ad99-6ef9400537ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16646028-57ac-4432-b1d7-e9779af30e37");

            migrationBuilder.AddColumn<string>(
                name: "PosterSource",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bf1bae-6b07-413c-997d-c815410f3902");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad37c2c-4d22-426a-bdd1-2c9286fbfc3a");

            migrationBuilder.DropColumn(
                name: "PosterSource",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "10e5c19f-c0e0-43ae-ad99-6ef9400537ba", "d031054b-4930-499a-bc5b-e47c2a9b237a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16646028-57ac-4432-b1d7-e9779af30e37", "1a417aa8-63f9-4d87-a20d-8313d1f9cdd5", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dba89085-2971-4834-9d48-25b1522ab2f8", "AQAAAAEAACcQAAAAEC44b1Cs5MjvZ8Lu3fFVMBBHCz037BW11Wenp4NB3JcmzHRBMA7h9m4PMQ0TG1EeJw==", "3de38aaf-e720-448e-8117-6069f41ec122" });
        }
    }
}
