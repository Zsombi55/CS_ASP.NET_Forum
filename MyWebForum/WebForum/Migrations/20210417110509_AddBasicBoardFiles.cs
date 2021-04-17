using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations
{
    public partial class AddBasicBoardFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Forums",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forums_BoardId",
                table: "Forums",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Boards_BoardId",
                table: "Forums",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Boards_BoardId",
                table: "Forums");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Forums_BoardId",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Forums");
        }
    }
}
