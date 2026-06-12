using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SNotCRetard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SSN",
                table: "Users",
                newName: "Ssn");

            migrationBuilder.RenameColumn(
                name: "LicenceNumber",
                table: "Users",
                newName: "LicenseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ssn",
                table: "Users",
                newName: "SSN");

            migrationBuilder.RenameColumn(
                name: "LicenseNumber",
                table: "Users",
                newName: "LicenceNumber");
        }
    }
}
