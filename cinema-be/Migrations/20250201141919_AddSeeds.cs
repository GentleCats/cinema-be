using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema_be.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Capacity", "Name", "Seat" },
                values: new object[,]
                {
                    { 1, 302, "Альфа", 0 },
                    { 2, 377, "Парадиз", 0 },
                    { 3, 346, "Арена", 0 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "EndTime", "HallId", "MovieId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 85, new TimeSpan(0, 19, 55, 0, 0) },
                    { 2, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 85, new TimeSpan(0, 19, 55, 0, 0) },
                    { 3, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 85, new TimeSpan(0, 19, 55, 0, 0) },
                    { 4, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 2, 426063, new TimeSpan(0, 10, 10, 0, 0) },
                    { 5, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 10, 0, 0), 2, 426063, new TimeSpan(0, 16, 20, 0, 0) },
                    { 6, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 2, 426063, new TimeSpan(0, 10, 10, 0, 0) },
                    { 7, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 10, 0, 0), 2, 426063, new TimeSpan(0, 16, 20, 0, 0) },
                    { 8, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 10, 0, 0), 3, 426063, new TimeSpan(0, 20, 10, 0, 0) },
                    { 9, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 10, 0, 0), 3, 426063, new TimeSpan(0, 20, 10, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
