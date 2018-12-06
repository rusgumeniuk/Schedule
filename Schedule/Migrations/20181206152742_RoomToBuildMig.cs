using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Migrations
{
    public partial class RoomToBuildMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "BuildId",
                table: "Rooms",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildId",
                table: "Rooms",
                newName: "IX_Rooms_BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildingId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Rooms",
                newName: "BuildId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                newName: "IX_Rooms_BuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildId",
                table: "Rooms",
                column: "BuildId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
