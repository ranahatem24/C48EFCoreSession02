using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C48EFCoreSession02.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAddressRelationShipOnetoOneMandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeAddress_City",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeAddress_Country",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeAddress_Street",
                table: "EmployeesTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeAddress_City",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmployeeAddress_Country",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmployeeAddress_Street",
                table: "EmployeesTable");
        }
    }
}
