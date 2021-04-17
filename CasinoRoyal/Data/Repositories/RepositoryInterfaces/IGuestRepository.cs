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
        int GetAllAdults();
        int GetAllChildren();
        int GetAllAdultsCheckedIn();
        int GetAllChildrenCheckedIn();
        int GetAllAdultsNotCheckedIn();
        int GetAllChildrenNotCheckedIn();
        int GetAllAdultsThatMadeReservation();
        int GetAllChildrenThatMadeReservation();
        bool ReservationPossible(int id);

        Guest GetSingleGuest(int id);
        void AddGuest(Guest guest);

    }
}
