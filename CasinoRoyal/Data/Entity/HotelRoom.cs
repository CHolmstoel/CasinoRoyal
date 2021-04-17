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
                return Guests.Where(t => t.GuestType == "Adult")
                    .Count(l => l.LastCheckInDate.Date == DateTime.Today.Date);
            }
        }

        [NotMapped]
        public int ChildrenBreakfastDone
        {
            get
            {
                return Guests.Where(t => t.GuestType == "Child")
                    .Count(l => l.LastCheckInDate.Date == DateTime.Today.Date);
            }
        }

        [NotMapped]
        public DateTime ReservationDate { get; set; }
    }
}
