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
        public List<Guest> Guests { get; set; }

        public int RoomIndex { get; set; }

        public int NumberOfRooms { get; set; }

        public string Type { get; set; }

        public SelectList DisplayRoomNumbers
        {
            get
            {
                return new SelectList(Enumerable.Range(1, NumberOfRooms).ToList(), selectedValue: RoomIndex);
            }
        }
    }
}
