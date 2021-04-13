using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public ApplicationDbContext Context
        {
            get { return Context as ApplicationDbContext; }
        }
        public GuestRepository(DbContext context) : base(context)
        {

        }
        public void AddGuest(Guest guest)
        {
            Context.Guest.Add(guest);
        }

        public int GetAllAdults()
        {
            return Context.Guest.Where(g => g.GuestType == "Adult").Count();
        }

        public int GetAllChildren()
        {
            return Context.Guest.Where(g => g.GuestType == "Child").Count();
        }

        public int GetAllGuests()
        {
            return Context.Guest.Count();
        }

        public Guest GetSingleGuest(int id)
        {
            return Context.Guest
                .Include(r => r.HotelRoom)
                .SingleOrDefault(i => i.GuestID == id);
        }

        public int GetAllAdultsCheckedIn()
        {
            return Context.Guest.Where(g => g.IsCheckedIn == true).Where(t => t.GuestType == "Adult").Count();
        }

        public int GetAllChildrenCheckedIn()
        {
            return Context.Guest.Where(g => g.IsCheckedIn == true).Where(t => t.GuestType == "Child").Count();
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
    }
}
