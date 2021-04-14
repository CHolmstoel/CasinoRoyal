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
        public IDataAccessAction DataAccess { get; set; }

        public WaiterViewModel()
        {
            
        }

        public WaiterViewModel(IDataAccessAction dataAccess)
        {
            DataAccess = dataAccess;
        }

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
        public List<int> GuestIDs { get; set; }

        [BindProperty]
        public Guest CurrentGuest { get; set; }

        [BindProperty]
        public List<string> GuestsIDsToAdd { get; set; }

        public int Index { get; set; }

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
