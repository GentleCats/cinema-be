using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace cinema_be.Migrations
{
    public partial class UpdateTicketSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Seat", table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "Tickets",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTime",
                table: "Tickets",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tickets",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Tickets",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Price", "BookingTime", "UserId", "SessionId", "Seat", "HallId" },
                values: new object[] { 100.5m, new DateTime(2024, 1, 1, 12, 0, 0), 1, 1, 10, 1 }); 

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Price", "BookingTime", "UserId", "SessionId", "Seat", "HallId" },
                values: new object[] { 150.0m, new DateTime(2024, 1, 2, 15, 30, 0), 2, 2, 5, 1 }); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(name: "BookingTime", table: "Tickets");
            migrationBuilder.DropColumn(name: "UserId", table: "Tickets");
            migrationBuilder.DropColumn(name: "SessionId", table: "Tickets");
            migrationBuilder.DropColumn(name: "Seat", table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Tickets",
                nullable: false,
                defaultValue: 1);
        }
    }
}
