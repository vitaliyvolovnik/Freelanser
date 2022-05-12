using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelanser.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Users_CustomerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Users_EmployeeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeesEmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customer_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Employee_WorkerEmployeeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Customer_CustomerId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employee_WorkerEmployeeId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employees_EmployeesEmployeeId",
                table: "EmployeeSkill",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Employees_WorkerEmployeeId",
                table: "Reviews",
                column: "WorkerEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Customers_CustomerId",
                table: "Works",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_WorkerEmployeeId",
                table: "Works",
                column: "WorkerEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_EmployeeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employees_EmployeesEmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Employees_WorkerEmployeeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Customers_CustomerId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_WorkerEmployeeId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Users_CustomerId",
                table: "Customer",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Users_EmployeeId",
                table: "Employee",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeesEmployeeId",
                table: "EmployeeSkill",
                column: "EmployeesEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customer_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Employee_WorkerEmployeeId",
                table: "Reviews",
                column: "WorkerEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Customer_CustomerId",
                table: "Works",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employee_WorkerEmployeeId",
                table: "Works",
                column: "WorkerEmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
