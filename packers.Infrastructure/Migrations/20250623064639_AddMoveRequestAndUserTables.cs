using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoveRequestAndUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SourceAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoveRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoveRequests_UserId",
                table: "MoveRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoveRequests");
        }
    }
}
