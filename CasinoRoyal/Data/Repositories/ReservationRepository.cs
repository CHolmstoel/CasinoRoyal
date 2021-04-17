using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

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
            return context.Reservations.Where(r => DateTime.Today.Date <= r.Date && r.Date <= DateTime.Today.AddDays(5).Date).Include(g => g.Guests).ToList();
        }

        public Reservation GetSingleReservation(int id)
        {
            return context.Reservations.SingleOrDefault(i => i.ReservationID == id);
        }

        public void MakeReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }

        public void CancelAllReservations()
        {
            context.RemoveRange(GetAllReservations());
        }
    }
}
