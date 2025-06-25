using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedServicesAndMoveTimeToMoveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "MoveTime",
                table: "MoveRequests",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedServices",
                table: "MoveRequests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoveTime",
                table: "MoveRequests");

            migrationBuilder.DropColumn(
                name: "SelectedServices",
                table: "MoveRequests");
        }
    }
}
