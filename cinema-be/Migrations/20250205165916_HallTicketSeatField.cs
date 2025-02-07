using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinema_be.Migrations
{
    /// <inheritdoc />
    public partial class HallTicketSeatField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Col",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cols",
                table: "Halls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rows",
                table: "Halls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cols", "Rows" },
                values: new object[] { 22, 14 });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cols", "Rows" },
                values: new object[] { 21, 18 });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cols", "Rows" },
                values: new object[] { 23, 15 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Col",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Cols",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "Rows",
                table: "Halls");
        }
    }
}
