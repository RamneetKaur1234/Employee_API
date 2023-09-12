using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_FirstAPI_Employee.Migrations
{
    public partial class adddeptsandemps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee1_Department1_DepartmentId",
                table: "Employee1");

            migrationBuilder.DropIndex(
                name: "IX_Employee1_DepartmentId",
                table: "Employee1");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employee1");

            migrationBuilder.AddColumn<int>(
                name: "Department1Id",
                table: "Employee1",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentEmployee",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentEmployee", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Department1_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentEmployee_Employee1_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee1_Department1Id",
                table: "Employee1",
                column: "Department1Id");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentEmployee_DepartmentId",
                table: "DepartmentEmployee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee1_Department1_Department1Id",
                table: "Employee1",
                column: "Department1Id",
                principalTable: "Department1",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee1_Department1_Department1Id",
                table: "Employee1");

            migrationBuilder.DropTable(
                name: "DepartmentEmployee");

            migrationBuilder.DropIndex(
                name: "IX_Employee1_Department1Id",
                table: "Employee1");

            migrationBuilder.DropColumn(
                name: "Department1Id",
                table: "Employee1");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employee1",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee1_DepartmentId",
                table: "Employee1",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee1_Department1_DepartmentId",
                table: "Employee1",
                column: "DepartmentId",
                principalTable: "Department1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
