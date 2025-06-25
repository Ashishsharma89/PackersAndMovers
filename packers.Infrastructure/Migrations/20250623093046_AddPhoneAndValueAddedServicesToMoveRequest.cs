using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneAndValueAddedServicesToMoveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "MoveRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValueAddedServices",
                table: "MoveRequests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "MoveRequests");

            migrationBuilder.DropColumn(
                name: "ValueAddedServices",
                table: "MoveRequests");
        }
    }
}
