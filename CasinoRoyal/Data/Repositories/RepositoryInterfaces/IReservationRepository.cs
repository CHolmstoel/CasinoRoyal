using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IReservationRepository: IRepository<Reservation>
    {
        public List<Reservation> GetAllReservations();
        public Reservation GetSingleReservation(int id);
        public void MakeReservation(Reservation reservation);

        public void CancelAllReservations();

    }
}
