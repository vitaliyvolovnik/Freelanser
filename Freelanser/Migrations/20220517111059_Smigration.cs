using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class Smigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_WorkerId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Works",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_WorkerId",
                table: "Works",
                newName: "IX_Works_EmployeeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublicshed",
                table: "Works",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainComment",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainCategory",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "IsPublicshed",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "IsMainComment",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsMainCategory",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Works",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_EmployeeId",
                table: "Works",
                newName: "IX_Works_WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_WorkerId",
                table: "Works",
                column: "WorkerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
