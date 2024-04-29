using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaisgood.Migrations
{
    /// <inheritdoc />
    public partial class updatefixdatatostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpiryDate",
                table: "payment_information",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "BillingAddresses",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "BillingAddresses");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExpiryDate",
                table: "payment_information",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
