using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaisgood.Migrations
{
    /// <inheritdoc />
    public partial class Totalpriceperiteminordertabmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceperItem",
                table: "Orderlistdbz",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceperItem",
                table: "Orderlistdbz");
        }
    }
}
