using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreIdentityApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Update_BirthDate_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirtyDay",
                table: "AspNetUsers",
                newName: "BirtyDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirtyDate",
                table: "AspNetUsers",
                newName: "BirtyDay");
        }
    }
}
