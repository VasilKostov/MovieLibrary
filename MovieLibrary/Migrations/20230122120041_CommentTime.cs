using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class CommentTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b53baf4-204e-4f0e-831e-2cc48faf3d4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b441bb7f-0200-4cbe-841f-09c9c56c5581");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedTime",
                table: "MovieComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8654b227-80a7-4d7f-9706-6fc10dd41c30", "053cee2e-f8a8-4543-aa0c-7850f9142b7f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89b4febd-426d-4408-bc9f-cf7a734357e8", "2700bec0-f76c-40dd-9fe0-b24a44ef3f28", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f221bfa5-8236-4bdc-840b-8ea19aaa1421", "AQAAAAEAACcQAAAAEGzouDJbt9KmhM0uBvxI7jLdJWIQQqlv7Y7PvDWvf+K2F/KYc1MZbou76R2QufPhGA==", "bc7c7f37-2482-469e-9d7a-462b33b5577d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8654b227-80a7-4d7f-9706-6fc10dd41c30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b4febd-426d-4408-bc9f-cf7a734357e8");

            migrationBuilder.DropColumn(
                name: "PostedTime",
                table: "MovieComments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b53baf4-204e-4f0e-831e-2cc48faf3d4a", "b19c43ad-87c2-44a6-862c-cf10c9ebcb09", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b441bb7f-0200-4cbe-841f-09c9c56c5581", "e44b9757-3961-4049-a246-bbc5980710da", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e6273d5-d47e-486e-a079-1114649ec9b8", "AQAAAAEAACcQAAAAEMN33dOMPH5Uoiwi1jRKczT7LB4geRIGvhA3KDKhdctbN3jTEqm9yHQkJXo1Q4q1Hw==", "eaa7d47c-1eab-4494-9a8c-855415b4360f" });
        }
    }
}
