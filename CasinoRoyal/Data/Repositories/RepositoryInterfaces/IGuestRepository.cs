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
        public void MakeReservation(int id, DateTime date);
        public void CheckIn(int id);
        public void CheckOutAll();
        void CheckOutGuest(Guest guest);
        int GetAllAdults();
        int GetAllChildren();
        int GetAllAdultsCheckedIn();
        int GetAllChildrenCheckedIn();
        int GetAllAdultsNotCheckedIn();
        int GetAllChildrenNotCheckedIn();
        bool ReservationPossible(int id, DateTime date);
        bool GuestExists(int id);
        Guest GetSingleGuest(int id);
        void AddGuest(Guest guest);

    }
}
