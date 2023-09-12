using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_FirstAPI_Employee.Migrations
{
    public partial class empty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentEmployee_Department1_DepartmentId",
                table: "DepartmentEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentEmployee_Employee1_EmployeeId",
                table: "DepartmentEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentEmployee",
                table: "DepartmentEmployee");

            migrationBuilder.RenameTable(
                name: "DepartmentEmployee",
                newName: "DeptsEmps");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentEmployee_DepartmentId",
                table: "DeptsEmps",
                newName: "IX_DeptsEmps_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeptsEmps",
                table: "DeptsEmps",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DeptsEmps_Department1_DepartmentId",
                table: "DeptsEmps",
                column: "DepartmentId",
                principalTable: "Department1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeptsEmps_Employee1_EmployeeId",
                table: "DeptsEmps",
                column: "EmployeeId",
                principalTable: "Employee1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeptsEmps_Department1_DepartmentId",
                table: "DeptsEmps");

            migrationBuilder.DropForeignKey(
                name: "FK_DeptsEmps_Employee1_EmployeeId",
                table: "DeptsEmps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeptsEmps",
                table: "DeptsEmps");

            migrationBuilder.RenameTable(
                name: "DeptsEmps",
                newName: "DepartmentEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_DeptsEmps_DepartmentId",
                table: "DepartmentEmployee",
                newName: "IX_DepartmentEmployee_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentEmployee",
                table: "DepartmentEmployee",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentEmployee_Department1_DepartmentId",
                table: "DepartmentEmployee",
                column: "DepartmentId",
                principalTable: "Department1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentEmployee_Employee1_EmployeeId",
                table: "DepartmentEmployee",
                column: "EmployeeId",
                principalTable: "Employee1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
