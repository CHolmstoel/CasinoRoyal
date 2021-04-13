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
    }
}
