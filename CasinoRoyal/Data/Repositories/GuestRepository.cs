﻿using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
            Context.Guest.AddAsync(guest);
        }

        public int GetAllAdults()
        {
            return Context.Guest.Count(g => g.GuestType == "Adult");
        }

        public int GetAllChildren()
        {
            return Context.Guest.Count(g => g.GuestType == "Child");
        }

        public List<Guest> GetAllGuests()
        {
            return Context.Guest
                .Include(h => h.HotelRoom)
                .OrderBy(p=>p.HotelRoomID)
                .ToList();
        }

        public Guest GetSingleGuest(int id)
        {
            return Context.Guest
                .Include(r => r.HotelRoom)
                .SingleOrDefault(i => i.GuestID == id);
        }

        public void CheckInGuest(int id)
        {
            var guest = Context.Guest
                .SingleOrDefault(g => g.GuestID == id);
            
            if (guest != null)
                guest.IsCheckedIn = true;
        }

        public int GetAllAdultsCheckedIn()
        {
            return Context.Guest.Where(g => g.GuestType == "Adult").Count(g => g.IsCheckedIn);
        }

        public int GetAllChildrenCheckedIn()
        {
            return Context.Guest.Where(g => g.GuestType == "Child").Count(g => g.IsCheckedIn);
        }

        public int GetAllAdultsNotCheckedIn()
        {
            return Context.Guest.Where(g => g.IsCheckedIn == false).Where(t => t.GuestType == "Adult").Count();
        }

        public int GetAllChildrenNotCheckedIn()
        {
            return Context.Guest.Where(g => g.IsCheckedIn == false).Where(t => t.GuestType == "Child").Count();
        }

        public int GetAllAdultsThatHasEaten()
        {
            return Context.Guest.Where(g => g.HasEatenBreakfast == true).Where(t => t.GuestType == "Adult").Count();
        }

        public int GetAllChildrenThatHasEaten()
        {
            return Context.Guest.Where(g => g.HasEatenBreakfast == true).Where(t => t.GuestType == "Child").Count();
        }

        public int GetAllAdultsThatHasNotEaten()
        {
            return Context.Guest.Where(g => g.HasEatenBreakfast == false).Where(t => t.GuestType == "Adult").Count();
        }

        public int GetAllChildrenThatHasNotEaten()
        {
            return Context.Guest.Where(g => g.HasEatenBreakfast == false).Where(t => t.GuestType == "Child").Count();
        }

        public void CheckOutGuest(Guest guest)
        {
            Context.Guest.Remove(guest);
        }
    }
}
