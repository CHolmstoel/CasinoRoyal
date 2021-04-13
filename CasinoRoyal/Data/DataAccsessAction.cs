using CasinoRoyal.Data.Repositories;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data
{
    public class DataAccsessAction : IDataAccessAction
    {
        private readonly ApplicationDbContext _context;
        public IHotelRoomRepository HotelRooms { get; private set; }

        public IGuestRepository Guests { get; private set; }

        public DataAccsessAction(ApplicationDbContext context)
        {
            _context = context;
            HotelRooms = new HotelRoomRepository(_context);
            Guests = new GuestRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
