using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasinoRoyal.Migrations
{
    public partial class AddedDateTimeToGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_HotelRooms_HotelRoomID",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "BreakfastReservationDate",
                table: "HotelRooms");

            migrationBuilder.AlterColumn<int>(
                name: "HotelRoomID",
                table: "Guest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BreakfastReservationDate",
                table: "Guest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_HotelRooms_HotelRoomID",
                table: "Guest",
                column: "HotelRoomID",
                principalTable: "HotelRooms",
                principalColumn: "HotelRoomID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_HotelRooms_HotelRoomID",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "BreakfastReservationDate",
                table: "Guest");

            migrationBuilder.AddColumn<DateTime>(
                name: "BreakfastReservationDate",
                table: "HotelRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "HotelRoomID",
                table: "Guest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_HotelRooms_HotelRoomID",
                table: "Guest",
                column: "HotelRoomID",
                principalTable: "HotelRooms",
                principalColumn: "HotelRoomID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
