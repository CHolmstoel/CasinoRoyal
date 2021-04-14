using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasinoRoyal.Migrations
{
    public partial class addedDateTimeToHotelRoomEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BreakfastReservationDate",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakfastReservationDate",
                table: "HotelRooms");
        }
    }
}
