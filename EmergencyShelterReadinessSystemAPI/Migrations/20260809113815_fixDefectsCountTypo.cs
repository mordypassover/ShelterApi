using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyShelterReadinessSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixDefectsCountTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefectsCountv",
                table: "Inspections",
                newName: "DefectsCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefectsCount",
                table: "Inspections",
                newName: "DefectsCountv");
        }
    }
}
