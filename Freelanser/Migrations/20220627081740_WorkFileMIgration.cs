using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class WorkFileMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkId1",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_WorkId1",
                table: "Files",
                column: "WorkId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Works_WorkId1",
                table: "Files",
                column: "WorkId1",
                principalTable: "Works",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Works_WorkId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_WorkId1",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "WorkId1",
                table: "Files");
        }
    }
}
