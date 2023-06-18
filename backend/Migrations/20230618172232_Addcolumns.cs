using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerdisc.Migrations
{
    /// <inheritdoc />
    public partial class Addcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastNotification",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNotification",
                table: "Students");
        }
    }
}
