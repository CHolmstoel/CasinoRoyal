using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasinoRoyal.Data.Entity
{
    public class Guest
    {
        public Guest()
        {
            LastReservationDate = DateTime.Now;
        }

        [Key]
        public int GuestID{ get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool CheckedIn { get; set; }
        public bool MadeReservation { get; set; }
        public string GuestType { get; set; }

        public DateTime LastReservationDate { get; set; }

        public DateTime LastCheckInDate { get; set; }

        [ForeignKey("HotelRoomID")]
        public HotelRoom HotelRoom { get; set; }

        [ForeignKey("HotelRoomID")]
        public int HotelRoomID { get; set; }

        [ForeignKey("ReservationID")]
        public int ReservationID { get; set; }

        public List<Reservation> Reservations { get; set; }


        [NotMapped]
        public string LastReservationDateDisplay { get => LastReservationDate.ToString("D"); set => DateTime.Parse(value); }

    }
}
