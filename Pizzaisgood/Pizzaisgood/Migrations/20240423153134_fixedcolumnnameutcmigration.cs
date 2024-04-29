using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaisgood.Migrations
{
    /// <inheritdoc />
    public partial class fixedcolumnnameutcmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataTimedelivered",
                table: "payment_information",
                newName: "ArchiviedUTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArchiviedUTC",
                table: "payment_information",
                newName: "DataTimedelivered");
        }
    }
}
