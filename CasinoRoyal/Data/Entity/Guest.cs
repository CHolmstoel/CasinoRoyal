using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Entity
{
    public class Guest
    {
        [Key]
        public int GuestID{ get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCheckedIn { get; set; }
        public bool HasEatenBreakfast { get; set; }
        public string GuestType { get; set; }
        public DateTime BreakfastReservationDate { get; set; }

        [ForeignKey("HotelRoomID")]
        public HotelRoom HotelRoom { get; set; }

        [ForeignKey("HotelRoomID")]

        public int HotelRoomID { get; set; }

    }
}
