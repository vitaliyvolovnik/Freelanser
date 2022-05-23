using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class ChangeWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryWork");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Skill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_CategoryId",
                table: "Works",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_WorkId",
                table: "Skill",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Works_WorkId",
                table: "Skill",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Categories_CategoryId",
                table: "Works",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Works_WorkId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Categories_CategoryId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CategoryId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Skill_WorkId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Skill");

            migrationBuilder.CreateTable(
                name: "CategoryWork",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    WorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryWork", x => new { x.CategoriesId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_CategoryWork_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryWork_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryWork_WorksId",
                table: "CategoryWork",
                column: "WorksId");
        }
    }
}
