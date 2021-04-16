using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Entity
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("GuestID")]
        public int GuestID { get; set; }
        
        public List<Guest> Guests { get; set; }
    }
}
