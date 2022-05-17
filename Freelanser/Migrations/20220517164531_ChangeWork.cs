using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class ChangeWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_EmployeeId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_WorkerId",
                table: "Works",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_WorkerId",
                table: "Works",
                column: "WorkerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_WorkerId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_WorkerId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_EmployeeId",
                table: "Works",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
