using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal.Models
{
    public class ReceptionistViewModel
    {
        public int TotalBreakfasts { get; set; }
        public List<HotelRoom> HotelRooms { get; set; }
        public Guest GuestToAdd { get; set; }
    }
}
