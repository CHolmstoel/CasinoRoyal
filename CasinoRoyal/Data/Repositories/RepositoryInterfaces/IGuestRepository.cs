using CasinoRoyal.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IGuestRepository: IRepository<Guest>
    {
        int GetAllGuests();
        int GetAllAdults();
        int GetAllChildren();
        Guest GetSingleGuest(int id);
        void AddGuest(Guest guest);

    }
}
