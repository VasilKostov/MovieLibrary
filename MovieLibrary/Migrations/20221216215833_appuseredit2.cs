using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class appuseredit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "6ff1c6e1-8efd-40f1-9a4d-e571a235f10b", "bf3d9143-6ee8-4b77-84b0-30b2821526a7", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be2fe6a6-6ccb-4c5c-b546-51b6f532a152", "fd9d675c-18da-42f1-931a-1958448d3b72", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbc8bb7-e361-4abf-aa19-a0e7d159b415", "AQAAAAEAACcQAAAAENcU8HHuu0/EPdK/wuHaPOy2OT2S4ZFi5SG5LDtEKp1/JFLUu92tsCYeE+19UowWTw==", "c37da27b-2877-4af8-9c16-48c24d4f420a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ff1c6e1-8efd-40f1-9a4d-e571a235f10b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be2fe6a6-6ccb-4c5c-b546-51b6f532a152");

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
    }
}
