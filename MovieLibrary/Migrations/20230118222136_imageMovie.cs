using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieLibrary.Migrations
{
    public partial class imageMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0707b619-a456-43c9-8381-9c0dfe3a99f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8185840-eee4-4a1c-b094-056d6be8c554");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b53baf4-204e-4f0e-831e-2cc48faf3d4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b441bb7f-0200-4cbe-841f-09c9c56c5581");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0707b619-a456-43c9-8381-9c0dfe3a99f1", "1d38bb1c-49c0-4c21-964e-b4b4784f76eb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8185840-eee4-4a1c-b094-056d6be8c554", "5b6e7124-fd2d-4956-bd90-0b290297c6e5", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3a03df-51a8-4087-8663-ab15bc5c2db4", "AQAAAAEAACcQAAAAEFYRv4lmkMAmSrYkiS9vy7rTPZX6tHW6JDt3BaLcR5yMRVAw2oARUaK53TcX11o+PA==", "a0ebac5a-7660-43de-b0f9-2717b7d44596" });
        }
    }
}
