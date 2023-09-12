using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_FirstAPI_Employee.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "ConfirmPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Users",
                newName: "Role");
        }
    }
}
