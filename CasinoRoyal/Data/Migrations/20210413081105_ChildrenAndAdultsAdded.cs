using Microsoft.EntityFrameworkCore.Migrations;

namespace CasinoRoyal.Data.Migrations
{
    public partial class ChildrenAndAdultsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelRoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.HotelRoomID);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    HasEatenBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    GuestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelRoom = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_Guest_HotelRooms_GuestID",
                        column: x => x.GuestID,
                        principalTable: "HotelRooms",
                        principalColumn: "HotelRoomID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "HotelRooms");
        }
    }
}
