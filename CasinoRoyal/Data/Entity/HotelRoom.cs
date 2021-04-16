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
        public List<Guest> Guests { get; set; }


        [NotMapped]
        public int AdultsBreakfastDone
        {
            get
            {
                return Guests.Where(t => t.GuestType == "Adult").Where(l => l.LastCheckInDate == DateTime.Today).Count(g => g.CheckedIn);
            }
        }

        [NotMapped]
        public int ChildrenBreakfastDone
        {
            get
            {
                return Guests.Where(t => t.GuestType == "Child").Where(l => l.LastCheckInDate == DateTime.Today).Count(g => g.CheckedIn);
            }
        }

        [NotMapped]
        public DateTime ReservationDate { get; set; }
    }
}
