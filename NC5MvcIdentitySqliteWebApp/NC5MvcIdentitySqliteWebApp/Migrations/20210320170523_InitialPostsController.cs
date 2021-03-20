using Microsoft.EntityFrameworkCore.Migrations;

namespace NC5MvcIdentitySqliteWebApp.Migrations
{
    public partial class InitialPostsController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Post",
                newName: "Creator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Post",
                newName: "CreatorId");
        }
    }
}
