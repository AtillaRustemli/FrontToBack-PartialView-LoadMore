using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class addedConnectionIdToAppUSer : Migration
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
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd0f2f65-ad74-4a23-8aac-dbe27fb7d542", "61cc6173-c9b8-4d71-9e74-b5c42f03cfa9", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d03d5da0-72e6-4702-a607-91ef021a217d", "1c83ca91-8bd1-4625-9fe5-3636402c4fb5", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec60c1f2-abc5-425d-b7f7-20f3296caead", "0a45966c-4dff-4d00-af8d-bcbb61e6d31a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd0f2f65-ad74-4a23-8aac-dbe27fb7d542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d03d5da0-72e6-4702-a607-91ef021a217d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec60c1f2-abc5-425d-b7f7-20f3296caead");

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
