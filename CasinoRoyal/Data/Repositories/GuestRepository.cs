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

        public void CheckInGuest(int id)
        {
            var guest = context.Guest
                .SingleOrDefault(g => g.GuestID == id);
            
            if (guest != null)
                guest.CheckedIn = true;
        }

        public void CheckOutAllGuests()
        {
            var guests = context.Guest.Where(i => i.CheckedIn);
            
            foreach (var guest in guests)
            {
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
            Context.Guest.Remove(guest);
        }
    }
}
