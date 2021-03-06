using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CasinoRoyal.Data.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }
        public GuestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddGuest(Guest guest)
        {
            context.Guest.AddAsync(guest);
        }

        public int GetAllAdults()
        {
            return context.Guest.Count(g => g.GuestType == "Adult");
        }

        public int GetAllChildren()
        {
            return context.Guest.Count(g => g.GuestType == "Child");
        }

        public List<Guest> GetAllGuests()
        {
            return context.Guest
                .Include(h => h.HotelRoom)
                .OrderBy(p=>p.HotelRoomID)
                .ToList();
        }

        public Guest GetSingleGuest(int id)
        {
            return context.Guest
                .Include(r => r.HotelRoom)
                .SingleOrDefault(i => i.GuestID == id);
        }

        public void MakeReservation(int id, DateTime date)
        {
            var guest = context.Guest.Include(g => g.Reservations).SingleOrDefault(i => i.GuestID == id);

            if (guest.Reservations == null)
            {
                guest.Reservations = new List<Reservation>();
            }

            if (guest.Reservations.Any(d => d.Date.Date == date.Date))
            {
                var reservationToRemove = guest.Reservations.SingleOrDefault(d => d.Date.Date == date.Date);

                if (reservationToRemove != null)
                {
                    guest.Reservations.Remove(reservationToRemove);
                    context.Reservations.Remove(reservationToRemove);
                }
            }

            if (date.Date == DateTime.Today.Date)
            {
                guest.CheckedIn = false;
            }

            var reservation = new Reservation() {Date = date, GuestID = guest.GuestID};
            context.Reservations.Add(reservation);
            guest.Reservations.Add(reservation);
            guest.LastReservationDate = date;
            guest.MadeReservation = true;
        }


        public void CheckIn(int id)
        {
            var guest = context.Guest
                .SingleOrDefault(g => g.GuestID == id);

            if (guest != null)
            {
                var reservation = context.Reservations.Include(g => g.Guests).Where(r => r.Date == DateTime.Today.Date).SingleOrDefault(g => g.GuestID == id);

                if (reservation != null)
                {
                    context.Reservations.Remove(reservation);
                    guest.Reservations.Remove(reservation);
                }
                
                guest.LastCheckInDate = DateTime.Now;
                guest.CheckedIn = true;
                guest.MadeReservation = false;
            }
        }

        public void CheckOutAll()
        {
            var guests = context.Guest.ToList();
            
            foreach (var guest in guests)
            {
                guest.LastCheckInDate = DateTime.MinValue;
                guest.CheckedIn = false;
            }
        }

        public int GetAllAdultsCheckedIn()
        {
            return context.Guest.Where(g => g.GuestType == "Adult").Count(g => g.CheckedIn);
        }

        public int GetAllChildrenCheckedIn()
        {
            return context.Guest.Where(g => g.GuestType == "Child").Count(g => g.CheckedIn);
        }

        public int GetAllAdultsNotCheckedIn()
        {
            return context.Guest.Where(g => g.CheckedIn == false).Count(t => t.GuestType == "Adult");
        }

        public int GetAllChildrenNotCheckedIn()
        {
            return context.Guest.Where(g => g.CheckedIn == false).Count(t => t.GuestType == "Child");
        }

        public int GetAllAdultsThatMadeReservation()
        {
            return context.Guest.Where(g => g.MadeReservation).Count(t => t.GuestType == "Adult");
        }

        public int GetAllChildrenThatMadeReservation()
        {
            return context.Guest.Where(g => g.MadeReservation).Count(t => t.GuestType == "Child");
        }

        public List<Guest> GetAllGuestsEatenToday()
        {
            var ReservationsForToday = context.Reservations.Where(d => d.Date == DateTime.Today).Include(g => g.Guests)
                .ToList();

            var guests = new List<Guest>();

            foreach (var reservation in ReservationsForToday)
            {
                foreach (var guest in reservation.Guests)
                {
                    if (guest.CheckedIn)
                    {
                        guests.Add(guest);
                    }   
                }
            }

            return guests;
        }

        public void CheckOutGuest(Guest guest)
        {
            context.Guest.Remove(guest);
        }

        public bool GuestExists(int id)
        {
            return context.Guest.Any(g => g.GuestID == id);
        }

        public bool ReservationPossible(int id, DateTime date)
        {
            var guest = context.Guest.SingleOrDefault(i => i.GuestID == id);
            if (guest.LastCheckInDate.Date == DateTime.Today.Date )
            {
                if (date.Date == DateTime.Today.Date)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
    }
}
