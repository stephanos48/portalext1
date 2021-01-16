using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    public partial class landingpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoPlans",
                columns: table => new
                {
                    PoPlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PoNumber = table.Column<string>(type: "text", nullable: true),
                    PoLine = table.Column<string>(type: "text", nullable: true),
                    Supplier = table.Column<string>(type: "text", nullable: true),
                    CustomerOrderNumber = table.Column<string>(type: "text", nullable: true),
                    SoNumber = table.Column<string>(type: "text", nullable: true),
                    OrderDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CustomerPn = table.Column<string>(type: "text", nullable: true),
                    ExtremePn = table.Column<string>(type: "text", nullable: true),
                    PartDescription = table.Column<string>(type: "text", nullable: true),
                    OrderQty = table.Column<int>(type: "integer", nullable: false),
                    ReceivedQty = table.Column<int>(type: "integer", nullable: true),
                    ContainerId = table.Column<string>(type: "text", nullable: true),
                    ContainerUh = table.Column<string>(type: "text", nullable: true),
                    FreightFowarder = table.Column<string>(type: "text", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    AMS = table.Column<string>(type: "text", nullable: true),
                    BOL = table.Column<string>(type: "text", nullable: true),
                    Pallet = table.Column<string>(type: "text", nullable: true),
                    Invoice = table.Column<string>(type: "text", nullable: true),
                    ArrivalWk = table.Column<string>(type: "text", nullable: true),
                    RequestedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PromiseDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Shipdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Etadate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReceiptDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PoOrderStatus = table.Column<string>(type: "text", nullable: true),
                    PoSentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PoSentBy = table.Column<string>(type: "text", nullable: true),
                    PoConfirmedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PoConfirmedBy = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoPlans", x => x.PoPlanId);
                });

            migrationBuilder.CreateTable(
                name: "SoPlans",
                columns: table => new
                {
                    SoPlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    CustomerOrderNo = table.Column<string>(type: "text", nullable: false),
                    CustomerOrderLine = table.Column<string>(type: "text", nullable: true),
                    SoNumber = table.Column<string>(type: "text", nullable: true),
                    WoNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerPn = table.Column<string>(type: "text", nullable: true),
                    ExtremePn = table.Column<string>(type: "text", nullable: true),
                    PartDescription = table.Column<string>(type: "text", nullable: true),
                    OrderQty = table.Column<int>(type: "integer", nullable: false),
                    ShipQty = table.Column<int>(type: "integer", nullable: true),
                    RequestedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PromiseDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ShipDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ShipPlanStatus = table.Column<string>(type: "text", nullable: true),
                    HotShipment = table.Column<string>(type: "text", nullable: true),
                    Carrier = table.Column<string>(type: "text", nullable: true),
                    TrackingInfo = table.Column<string>(type: "text", nullable: true),
                    ShipToAddress = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    InvNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoPlans", x => x.SoPlanId);
                });

            migrationBuilder.CreateTable(
                name: "TxQohs",
                columns: table => new
                {
                    TxQohId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pn = table.Column<string>(type: "text", nullable: true),
                    PartDescription = table.Column<string>(type: "text", nullable: true),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    Qoh = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    HtsCode = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TxQohs", x => x.TxQohId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoPlans");

            migrationBuilder.DropTable(
                name: "SoPlans");

            migrationBuilder.DropTable(
                name: "TxQohs");
        }
    }
}
