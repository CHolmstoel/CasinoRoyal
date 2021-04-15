using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CasinoRoyal.Models
{
    public class WaiterViewModel
    {
        public WaiterViewModel()
        {
        }

        [BindProperty]
        public HotelRoom CurrentRoom { get; set; }

        public List<Guest> Guests { get => CurrentRoom.Guests; set => CurrentRoom.Guests = value; }

        [BindProperty]
        public int RoomIndex { get; set; }

        [BindProperty]
        public int NumberOfRooms { get; set; }

        [BindProperty]
        public SelectList DisplayRoomNumbers
        {
            get
            {
                return new SelectList(Enumerable.Range(1, NumberOfRooms).ToList(), selectedValue: RoomIndex);
            }
        }
    }
}
