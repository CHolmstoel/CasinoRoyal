using CasinoRoyal.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IHotelRoomRepository: IRepository<HotelRoom>
    {
        List<HotelRoom> GetAllHotelRooms();
        HotelRoom GetSingleHotelRoom(int id);
        void AddHotelRoom(HotelRoom hotelRoom);
        int GetNumberOfHotelRooms();
    }
}
