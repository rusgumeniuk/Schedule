using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Migrations
{
    public partial class LessonAutoPropMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupId1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectId1",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId1",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TeacherId1",
                table: "Lessons",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "Lessons",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "GroupId1",
                table: "Lessons",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_TeacherId1",
                table: "Lessons",
                newName: "IX_Lessons_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SubjectId1",
                table: "Lessons",
                newName: "IX_Lessons_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_GroupId1",
                table: "Lessons",
                newName: "IX_Lessons_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Lessons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Lessons",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "LessonNumber",
                table: "Lessons",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "LessonType",
                table: "Lessons",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "WeekMode",
                table: "Lessons",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Rooms_RoomId",
                table: "Lessons",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Groups_GroupId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Rooms_RoomId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Subjects_SubjectId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_GroupId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonType",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "WeekMode",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Lessons",
                newName: "TeacherId1");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Lessons",
                newName: "SubjectId1");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Lessons",
                newName: "GroupId1");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                newName: "IX_Lessons_TeacherId1");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_SubjectId",
                table: "Lessons",
                newName: "IX_Lessons_SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_RoomId",
                table: "Lessons",
                newName: "IX_Lessons_GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Groups_GroupId1",
                table: "Lessons",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Subjects_SubjectId1",
                table: "Lessons",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId1",
                table: "Lessons",
                column: "TeacherId1",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
