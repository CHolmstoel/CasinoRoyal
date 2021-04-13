using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories
{
    public class HotelRoomRepository : Repository<HotelRoom>, IHotelRoomRepository
    {
        public ApplicationDbContext Context
        {
            get { return Context as ApplicationDbContext; }
        }
        public HotelRoomRepository(DbContext context) : base(context)
        {

        }
        public List<HotelRoom> GetAllHotelRooms()
        {
            return new List<HotelRoom>(Context.HotelRooms
                .Include(g => g.Guests)
                .ToList()
                );
        }
        public HotelRoom GetSingleHotelRoom(int id)
        {
            return Context.HotelRooms
                .Include(g => g.Guests)
                .SingleOrDefault(i => i.HotelRoomID == id);
        }
        public void AddHotelRoom(HotelRoom hotelRoom)
        {
            Context.HotelRooms.Add(hotelRoom);
        }
    }
}
