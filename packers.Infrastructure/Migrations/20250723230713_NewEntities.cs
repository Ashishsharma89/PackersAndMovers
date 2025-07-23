using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Packer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Orders",
                newName: "id");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Customer");

            migrationBuilder.CreateSequence<int>(
                name: "Seq_Tracking");

            migrationBuilder.AddColumn<DateTime>(
                name: "delivery_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "order_date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "order_id",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "'OID' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)",
                stored: true);

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_Customer"),
                    customer_id = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "'CUS' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)", stored: true),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tracking_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Seq_Tracking"),
                    tracking_id = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "'TID' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)", stored: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderTrackings");

            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "delivery_date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "order_date",
                table: "Orders");

            migrationBuilder.DropSequence(
                name: "Seq_Customer");

            migrationBuilder.DropSequence(
                name: "Seq_Tracking");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "'OID' + RIGHT('000000' + CAST([ID] AS VARCHAR), 6)",
                stored: true);
        }
    }
}
