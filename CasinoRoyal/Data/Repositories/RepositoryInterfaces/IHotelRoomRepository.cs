using CasinoRoyal.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    interface IHotelRoomRepository: IRepository<HotelRoom>
    {
        public List<HotelRoom> GetAllHotelRooms();
        public HotelRoom GetSingleHotelRoom(int id);
        public void AddHotelRoom(HotelRoom hotelRoom);
    }
}
