using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class addAllNotAddedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "77f1f82b-bf85-4fab-aa92-905d7aa3b4aa", "1c01c84c-6dfa-4483-a406-2df468bf1c90", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c62e1582-6730-4643-9d54-d31dae82af4f", "ce063da6-7fda-4528-8689-b9d41afe08f9", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb9803c5-fb79-43b1-9a3f-53cde26f9001", "b56367b8-500f-4e3b-8896-696f06033a9f", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77f1f82b-bf85-4fab-aa92-905d7aa3b4aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c62e1582-6730-4643-9d54-d31dae82af4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb9803c5-fb79-43b1-9a3f-53cde26f9001");

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
    }
}
