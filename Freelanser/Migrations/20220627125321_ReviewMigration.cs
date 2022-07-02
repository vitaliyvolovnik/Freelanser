using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class ReviewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_WorkId",
                table: "Reviews",
                column: "WorkId",
                unique: true,
                filter: "[WorkId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Works_WorkId",
                table: "Reviews",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Works_WorkId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_WorkId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Reviews");
        }
    }
}
