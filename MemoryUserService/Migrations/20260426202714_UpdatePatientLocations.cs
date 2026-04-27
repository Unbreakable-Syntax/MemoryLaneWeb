using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryUserService.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longtitude",
                table: "PatientLocations",
                newName: "Longitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "PatientLocations",
                newName: "Longtitude");
        }
    }
}
