using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Migrate_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Topics_TopicId1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TopicId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TopicId",
                table: "Messages",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Topics_TopicId",
                table: "Messages",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Topics_TopicId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TopicId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "TopicId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TopicId1",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TopicId1",
                table: "Messages",
                column: "TopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Topics_TopicId1",
                table: "Messages",
                column: "TopicId1",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
