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
        [Key] [Display(Name = "Room Number")] public int HotelRoomID { get; set; }
        public List<Guest> Guests { get; set; }

        [NotMapped] public DateTime ReservationDate { get; set; }

        [NotMapped]
        public int AdultsBreakfastDone => AdultsBreakfastDoneCalculator();

        [NotMapped]
        public int ChildrenBreakfastDone => ChildrenBreakfastDoneCalculator();

        private int AdultsBreakfastDoneCalculator()
        {
            var count = 0;

            foreach (var guest in Guests)
            {
                if (guest.GuestType == "Adult" && guest.Reservations.Any(d => d.Date.Date == DateTime.Today.Date))
                {
                    ++count;
                }
            }

            return count;
        }

        private int ChildrenBreakfastDoneCalculator()
        {
            var count = 0;

            foreach (var guest in Guests)
            {
                if (guest.GuestType == "Child" && guest.Reservations.Any(d => d.Date.Date == DateTime.Today.Date))
                {
                    ++count;
                }
            }

            return count;
        }
    }
}
