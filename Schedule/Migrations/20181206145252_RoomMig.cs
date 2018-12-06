using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Migrations
{
    public partial class RoomMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildId",
                table: "Rooms",
                column: "BuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Buildings_BuildId",
                table: "Rooms",
                column: "BuildId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Buildings_BuildId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BuildId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BuildId",
                table: "Rooms");
        }
    }
}
