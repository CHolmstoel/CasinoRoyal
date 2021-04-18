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
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Checked In")]
        public bool CheckedIn { get; set; }
        [Display(Name = "Reservation")]
        public bool MadeReservation { get; set; }
        [Display(Name = "Type")]
        public string GuestType { get; set; }

        public DateTime LastReservationDate { get; set; }

        public DateTime LastCheckInDate { get; set; }

        [ForeignKey("HotelRoomID")]
        public HotelRoom HotelRoom { get; set; }

        [ForeignKey("HotelRoomID")]
        [Display(Name = "Room No.")]
        public int HotelRoomID { get; set; }

        [ForeignKey("ReservationID")]
        public int ReservationID { get; set; }

        public List<Reservation> Reservations { get; set; }


        [NotMapped]
        public string LastReservationDateDisplay 
        { 
            get => LastReservationDate.ToString("D"); 
            set => LastReservationDate = DateTime.Parse(value);
        }

    }
}
