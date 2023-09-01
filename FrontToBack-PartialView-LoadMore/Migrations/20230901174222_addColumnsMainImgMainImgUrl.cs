using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class addColumnsMainImgMainImgUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImgIcon",
                table: "About",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainImgUrl",
                table: "About",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImgIcon",
                table: "About");

            migrationBuilder.DropColumn(
                name: "MainImgUrl",
                table: "About");
        }
    }
}
