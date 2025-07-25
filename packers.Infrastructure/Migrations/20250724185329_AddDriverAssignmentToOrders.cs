using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverAssignmentToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverAssignmentStatus",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "NotAssigned");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverAssignmentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Orders");
        }
    }
}
