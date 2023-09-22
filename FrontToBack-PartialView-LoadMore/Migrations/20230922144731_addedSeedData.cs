using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b38c3b4-a9a3-43c5-ac11-5d4862549858", "c841fd2d-bcbd-40b3-86b1-8c86f02c9a54", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bc046de-8813-47e7-ab58-2f7e945e74a5", "55f0c661-c70e-4605-93cd-d0c221e65f29", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a486db27-0d44-409e-8f89-c55a75437dce", "b4771af4-ba74-4962-bd04-d51ea4c882a8", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b38c3b4-a9a3-43c5-ac11-5d4862549858");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc046de-8813-47e7-ab58-2f7e945e74a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a486db27-0d44-409e-8f89-c55a75437dce");
        }
    }
}
