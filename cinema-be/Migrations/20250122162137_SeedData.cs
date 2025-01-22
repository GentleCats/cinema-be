using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinema_be.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Name", "Сapacity" },
                values: new object[,]
                {
                    { 1, "Альфа", 302 },
                    { 2, "Парадиз", 377 },
                    { 3, "Арена", 346 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "osadets@gmail.com", false, "Qwerty!", "Sasha Osadets" },
                    { 2, "fedor@gmail.com", false, "Qwerty!", "Fedor" },
                    { 3, "Maksym@gmail.com", false, "Qwerty!", "Maksym Banatskyi" },
                    { 4, "MaksymL@gmail.com", false, "Qwerty!", "Maksym Lazarchuk" },
                    { 5, "Volodymyr@gmail.com", false, "Qwerty!", "Volodymyr Yakovchuk" },
                    { 6, "admin@gmail.com", true, "psw!admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Date", "EndTime", "HallId", "MovieId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 1, new TimeSpan(0, 19, 55, 0, 0) },
                    { 2, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 1, new TimeSpan(0, 19, 55, 0, 0) },
                    { 3, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 45, 0, 0), 1, 1, new TimeSpan(0, 19, 55, 0, 0) },
                    { 4, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 2, 2, new TimeSpan(0, 10, 10, 0, 0) },
                    { 5, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 10, 0, 0), 2, 2, new TimeSpan(0, 16, 20, 0, 0) },
                    { 6, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 2, 2, new TimeSpan(0, 10, 10, 0, 0) },
                    { 7, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 10, 0, 0), 2, 2, new TimeSpan(0, 16, 20, 0, 0) },
                    { 8, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 10, 0, 0), 3, 3, new TimeSpan(0, 20, 10, 0, 0) },
                    { 9, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 22, 10, 0, 0), 3, 3, new TimeSpan(0, 20, 10, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "HallId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 250m },
                    { 2, 3, 220m },
                    { 3, 2, 230m }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingTime", "SessionId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 4, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 5, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

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
