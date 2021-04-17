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

        public string HotelRoomNumber => "Room Number";
        public string NumberOfAdults => "Adults";
        public string NumberOfChildren => "Children";
        

        //public int HotelRoomID { get; set; }
    }
}