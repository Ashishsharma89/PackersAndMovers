using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerFormSubmissionsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerFormSubmissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_submission_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_location_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_location_lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_location_long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distance_in_km = table.Column<int>(type: "int", nullable: false),
                    items_json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urgency = table.Column<bool>(type: "bit", nullable: false),
                    estimated_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    delivery_status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFormSubmissions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFormSubmissions");
        }
    }
}
