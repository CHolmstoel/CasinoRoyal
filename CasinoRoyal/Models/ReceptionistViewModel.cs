using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasinoRoyal.Models
{
    public class ReceptionistViewModel
    {
        public List<HotelRoom> HotelRooms { get; set; }
        public DateTime ReservationDate { get; set; }
        public HotelRoom CurrentRoom { get; set; }
        public Guest CurrentGuest { get; set; }
        public List<Reservation> Reservations { get; set; }

        public string HotelRoomNumber => "Room Number";
        public string Date => "Reservation Date";
        public string NumberOfAdults => "Adults";
        public string NumberOfChildren => "Children";
        
        public string ReservationDateDisplay
        {
            get => ReservationDate.ToString("D");
            set => DateTime.Parse(value);
        } 

        public Guest GuestToAdd { get; set; }

        [BindProperty]
        public int HotelRoomID { get; set; }

        [BindProperty]
        public int NumberOfRooms { get; set; }

        [BindProperty]
        public List<string> GuestsIDsToAdd { get; set; }

        [BindProperty]
        public SelectList RoomNumbers
        {
            get
            {
                return new SelectList(Enumerable.Range(1, NumberOfRooms).ToList(), selectedValue: HotelRoomID);
            }
        }
    }
}