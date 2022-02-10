using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DAL.Migrations
{
    public partial class Creator2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatorID",
                table: "Comments",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CreatorID",
                table: "Comments",
                column: "CreatorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CreatorID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreatorID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "Comments");
        }
    }
}
