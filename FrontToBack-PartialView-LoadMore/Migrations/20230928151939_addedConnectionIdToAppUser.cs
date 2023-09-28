using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class addedConnectionIdToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72a4ce78-7c83-49b0-acc5-0c93b72e4826", "1306881b-0f5d-4d22-b50c-755be8127957", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae5efc3c-f44e-4046-a1b1-d1ffa7ded965", "d19b034b-17e7-4e14-8d7a-c4098a7b03e1", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f727866a-f192-4a03-a855-d55ab6e888f7", "6a6199da-6ba5-41d9-a742-7f253cb0fa53", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72a4ce78-7c83-49b0-acc5-0c93b72e4826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5efc3c-f44e-4046-a1b1-d1ffa7ded965");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f727866a-f192-4a03-a855-d55ab6e888f7");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "AspNetUsers");

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
    }
}
