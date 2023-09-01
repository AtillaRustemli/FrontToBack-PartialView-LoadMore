using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontToBack_PartialView_LoadMore.Migrations
{
    public partial class about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutList_About_AboutId",
                        column: x => x.AboutId,
                        principalTable: "About",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutList_AboutId",
                table: "AboutList",
                column: "AboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutList");

            migrationBuilder.DropTable(
                name: "About");
        }
    }
}
