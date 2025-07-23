using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrdersEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Seq_Orders");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_Orders"),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "'OID' + RIGHT('000000' + CAST([ID] AS VARCHAR), 6)", stored: true),
                    origin_location_lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    origin_location_long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination_location_long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distance_in_km = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    items_json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urgency = table.Column<bool>(type: "bit", nullable: false),
                    estimated_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_DriverId",
                table: "Trucks",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropSequence(
                name: "Seq_Orders");
        }
    }
}
