using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema_be.Migrations
{
    /// <inheritdoc />
    public partial class TicketSeatFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Halls");

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Halls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                column: "Seat",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2,
                column: "Seat",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                column: "Seat",
                value: 0);
        }
    }
}
