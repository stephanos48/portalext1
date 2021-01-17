using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class correctedDatePoPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shipdate",
                table: "PoPlans",
                newName: "ShipDateTime");

            migrationBuilder.RenameColumn(
                name: "Etadate",
                table: "PoPlans",
                newName: "EtaDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipDateTime",
                table: "PoPlans",
                newName: "Shipdate");

            migrationBuilder.RenameColumn(
                name: "EtaDateTime",
                table: "PoPlans",
                newName: "Etadate");
        }
    }
}
