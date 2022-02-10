using Microsoft.EntityFrameworkCore.Migrations;

namespace TS.DAL.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "TicketID1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TicketID1",
                table: "Comments",
                column: "TicketID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketID1",
                table: "Comments",
                column: "TicketID1",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketID1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TicketID1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TicketID1",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketID",
                table: "Comments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
