using Microsoft.EntityFrameworkCore.Migrations;

namespace WebForum.Migrations
{
    public partial class NewThreadPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_CreatorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_PostId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadEntityId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_CreatorId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Forums_ForumEntityId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ForumEntityId",
                table: "Threads",
                newName: "ForumId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Threads",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_ForumEntityId",
                table: "Threads",
                newName: "IX_Threads_ForumId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CreatorId",
                table: "Threads",
                newName: "IX_Threads_UserId");

            migrationBuilder.RenameColumn(
                name: "ThreadEntityId",
                table: "Posts",
                newName: "ThreadId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThreadEntityId",
                table: "Posts",
                newName: "IX_Posts_ThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CreatorId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Threads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadId",
                table: "Posts",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Forums_ForumId",
                table: "Threads",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Threads_ThreadId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Forums_ForumId",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Threads");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Threads",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "ForumId",
                table: "Threads",
                newName: "ForumEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_UserId",
                table: "Threads",
                newName: "IX_Threads_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_ForumId",
                table: "Threads",
                newName: "IX_Threads_ForumEntityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "ThreadId",
                table: "Posts",
                newName: "ThreadEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ThreadId",
                table: "Posts",
                newName: "IX_Posts_ThreadEntityId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostId",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_CreatorId",
                table: "Posts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_PostId",
                table: "Posts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Threads_ThreadEntityId",
                table: "Posts",
                column: "ThreadEntityId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_CreatorId",
                table: "Threads",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Forums_ForumEntityId",
                table: "Threads",
                column: "ForumEntityId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
