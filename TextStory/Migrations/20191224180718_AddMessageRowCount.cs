using Microsoft.EntityFrameworkCore.Migrations;

namespace TextStory.Migrations
{
    public partial class AddMessageRowCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Story_StoryID",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "StoryID",
                table: "Message",
                newName: "StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_StoryID",
                table: "Message",
                newName: "IX_Message_StoryId");

            migrationBuilder.AddColumn<int>(
                name: "MessageRowCount",
                table: "Story",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StoryId",
                table: "Message",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Story_StoryId",
                table: "Message",
                column: "StoryId",
                principalTable: "Story",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Story_StoryId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "MessageRowCount",
                table: "Story");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "Message",
                newName: "StoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Message_StoryId",
                table: "Message",
                newName: "IX_Message_StoryID");

            migrationBuilder.AlterColumn<int>(
                name: "StoryID",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Story_StoryID",
                table: "Message",
                column: "StoryID",
                principalTable: "Story",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
