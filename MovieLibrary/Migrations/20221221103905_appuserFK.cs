using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class appuserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a8b2193-3356-4f44-b552-316690acd3e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1670c99-ff74-4629-9842-b899171b4583");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieComment");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "444e1128-4623-4620-97f6-0e094f29f8f1", "f405e39e-7414-4ebc-8a7a-53c14038c8c6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b7fb6598-8f66-4883-a236-2b60119732d5", "22312641-8184-43d7-bb78-5285c5a24002", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef3ef561-150d-4f30-be8a-1970921ba361", "AQAAAAEAACcQAAAAEMPrieZEuDZztHSH1ZspU7LsdpjKVjiZ7Ptw9Dn50/rrn8nDc4Qr5JQtY/GmaaIX7w==", "1cc6a9ff-327d-4e88-a536-4cc43b129762" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "444e1128-4623-4620-97f6-0e094f29f8f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7fb6598-8f66-4883-a236-2b60119732d5");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MovieComment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a8b2193-3356-4f44-b552-316690acd3e6", "f1b6d08a-6ee2-460d-ae84-5804816f966c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1670c99-ff74-4629-9842-b899171b4583", "5c045050-e17e-4752-bcae-60c1a75fe6cb", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "826c2aa3-479b-435f-b0b5-ae74e6e17c0a", "AQAAAAEAACcQAAAAEBBvtK+NDd3YlHcWSlDTLTcVLLSDC+OdTVFcrZCEpRnvIbVHqaiNgiVJkZpL/1PqUg==", "86cc0915-9f5e-4f4c-baf3-ba80bb48664a" });
        }
    }
}
