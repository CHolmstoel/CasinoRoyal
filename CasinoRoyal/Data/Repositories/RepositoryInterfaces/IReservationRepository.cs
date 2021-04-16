using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IReservationRepository: IRepository<Reservation>
    {
        List<Reservation> GetAllReservations();
        Reservation GetSingleReservation(int id);
        void MakeReservation(Reservation reservation);

    }
}
