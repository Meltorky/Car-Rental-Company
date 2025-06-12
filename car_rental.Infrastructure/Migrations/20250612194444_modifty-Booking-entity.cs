using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_rental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modiftyBookingentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDays",
                table: "Bookings");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BookingEndDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingEndDate",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingDays",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
