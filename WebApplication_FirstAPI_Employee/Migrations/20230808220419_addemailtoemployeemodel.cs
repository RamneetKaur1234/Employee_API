using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_FirstAPI_Employee.Migrations
{
    public partial class addemailtoemployeemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Employees");
        }
    }
}
