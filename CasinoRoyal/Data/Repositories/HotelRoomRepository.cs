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
        public ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }
        public HotelRoomRepository(ApplicationDbContext context) : base(context)
        {

        }
        public List<HotelRoom> GetAllHotelRooms()
        {
            return context.HotelRooms
                .Include(g => g.Guests)
                .ToList();
        }

        public HotelRoom GetSingleHotelRoom(int id)
        {
            return context.HotelRooms
                .Include(g => g.Guests)
                .SingleOrDefault(i => i.HotelRoomID == id);
        }

        public List<Guest> GetReservationsForRoom(int id)
        {
            return context.HotelRooms
                .Include(g => g.Guests)
                .SingleOrDefault(r => r.HotelRoomID == id)
                .Guests.Where(g => g.MadeReservation)
                .ToList();
        }

        public void AddHotelRoom(HotelRoom hotelRoom)
        {
            context.HotelRooms.Add(hotelRoom);
        }
        public int GetNumberOfHotelRooms()
        {
            return context.HotelRooms.Count();
        }
    }
}
