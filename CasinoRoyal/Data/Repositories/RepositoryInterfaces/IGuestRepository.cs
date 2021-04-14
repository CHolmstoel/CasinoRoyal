using CasinoRoyal.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IGuestRepository: IRepository<Guest>
    {
        List<Guest> GetAllGuests();
        public void CheckInGuest(int id);
        public void CheckOutGuest(Guest guest);
        int GetAllAdults();
        int GetAllChildren();
        int GetAllAdultsCheckedIn();
        int GetAllChildrenCheckedIn();
        int GetAllAdultsNotCheckedIn();
        int GetAllChildrenNotCheckedIn();
        int GetAllAdultsThatHasEaten();
        int GetAllChildrenThatHasEaten();
        int GetAllAdultsThatHasNotEaten();
        int GetAllChildrenThatHasNotEaten();
        Guest GetSingleGuest(int id);
        void AddGuest(Guest guest);

    }
}
