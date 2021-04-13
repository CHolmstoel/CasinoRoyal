using System;
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

        [ForeignKey("GuestID")]
        public List<Guest> Occupants { get; set; }
    }
}
