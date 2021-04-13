using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data
{
    public interface IDataAccessAction : IDisposable
    {
        IHotelRoomRepository HotelRooms { get; }
        IGuestRepository Guests { get; }
        int Complete();
    }
}
