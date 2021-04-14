using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasinoRoyal.Models
{
    public class WaiterViewModel
    {
        [BindProperty]
        public List<HotelRoom> HotelRooms { get; set; }

        [BindProperty]
        public List<Guest> Guests { get; set; }

        [BindProperty]
        public HotelRoom CurrentRoom { get; set; }

        [BindProperty]
        public int RoomIndex { get; set; }

        [BindProperty]
        public int NumberOfRooms { get; set; }

        [BindProperty]
        public List<Guest> GuestsToAdd { get; set; }

        [BindProperty]
        public SelectList RoomNumbers 
        {
            get
            {
                return new SelectList(Enumerable.Range(1, NumberOfRooms).ToList(), selectedValue: RoomIndex);
            }
        }
    }
}
