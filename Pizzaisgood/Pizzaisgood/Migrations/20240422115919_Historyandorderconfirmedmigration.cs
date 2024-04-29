using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaisgood.Migrations
{
    /// <inheritdoc />
    public partial class Historyandorderconfirmedmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataTimedelivered",
                table: "payment_information",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OrderCompleted",
                table: "payment_information",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTimedelivered",
                table: "payment_information");

            migrationBuilder.DropColumn(
                name: "OrderCompleted",
                table: "payment_information");
        }
    }
}
