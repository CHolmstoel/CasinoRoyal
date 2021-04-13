using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal.Models
{
    public class WaiterViewModel
    {
        public List<HotelRoom> HotelRooms { get; set; }
        public List<Guest> Guests { get; set; }
        public List<Guest> CheckedInGuests { get; set; }
        public int ChoosenRoom { get; set; }
    }
}
