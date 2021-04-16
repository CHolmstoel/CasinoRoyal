using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;

namespace CasinoRoyal.Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Reservation> GetAllReservations()
        {
            return context.Reservations.ToList();
        }

        public Reservation GetSingleReservation(int id)
        {
            return context.Reservations.SingleOrDefault(i => i.ReservationID == id);
        }

        public void MakeReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }
    }
}
