using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class appuseredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ab07d6e-87d0-4ab3-8639-1c2130e69c30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77f804f-4d91-4d3b-8cc9-a4455cee03ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2dadfdd6-9ac7-439a-856f-84fe0950fd84", "490673dd-4351-40e3-8c79-74bb8e6e765a", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7930b00-36be-462c-9f8e-ece649fa766c", "6e5f106a-e634-4afa-b695-913946d4d1c2", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8e25ff5-a5c0-438e-b5f4-a83255e9f88a", "AQAAAAEAACcQAAAAEGoLP+zmfryyEIHR+LXofyLVaGYsjO5y4AfuyafwHAw4RxVtAGxDN78+W4S2jn+qyg==", "e69b0297-7dac-43c6-962e-290ba41dd530" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dadfdd6-9ac7-439a-856f-84fe0950fd84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7930b00-36be-462c-9f8e-ece649fa766c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ab07d6e-87d0-4ab3-8639-1c2130e69c30", "2f31ea14-83b6-43e1-8403-6947684ca884", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e77f804f-4d91-4d3b-8cc9-a4455cee03ad", "b33b4a29-1678-428f-a5c8-e1cd7da179f1", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "800125bb-0a8b-44fb-b720-948f6d970d49", "AQAAAAEAACcQAAAAEC7xHMCJkIA4J8Ag+XXnZC1fjDFL0GnQW5r1iZpccW1qWZnGagbvl0TF32MWyIyTmQ==", "835c1383-b4fe-48cd-a54f-bfdea09e0dc8" });
        }
    }
}
