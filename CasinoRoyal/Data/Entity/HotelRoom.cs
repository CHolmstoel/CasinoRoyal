﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Entity
{
    public class HotelRoom
    {
        [Key]
        [Display(Name = "Room Number")]
        public int HotelRoomID { get; set; }

        public DateTime BreakfastReservationDate { get; set; }

        public List<Guest> Guests { get; set; }
    }
}
