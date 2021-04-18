using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Models;
using CasinoRoyal.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace CasinoRoyal.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IDataAccessAction _dataAccess;
        public ReceptionistController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccessAction(context);
        }

        // GET: Guests
        [Authorize("IsReceptionist")]
        public IActionResult Index()
        {
            var receptionistViewModel = new ReceptionistViewModel();
            receptionistViewModel.HotelRooms = _dataAccess.HotelRooms.GetAllHotelRooms();
            
            return View(receptionistViewModel);
        }

        [Authorize("IsReceptionist")]
        public async Task<IActionResult> GuestIndex()
        {
            var AllGuests = from g in _dataAccess.Guests.GetAllGuests() select g;
            return View(AllGuests);
        }

        [Authorize("IsReceptionist")]
        public IActionResult Book(string bookButton)
        {
            var receptionistViewModel = new ReceptionistViewModel();

            receptionistViewModel.CurrentRoom = _dataAccess.HotelRooms.GetSingleHotelRoom(int.Parse(bookButton));

            return View(receptionistViewModel);
        }

        [Authorize("IsReceptionist")]
        [HttpPost]
        public IActionResult CompleteGuest(ReceptionistViewModel receptionistViewModel, string bookButton)
        {
            //Hvis reservationen ligger idag, tjek for dette, ellers ikke
            if(_dataAccess.Guests.ReservationPossible(receptionistViewModel.CurrentGuest.GuestID,receptionistViewModel.CurrentGuest.LastReservationDate))
            { 
                _dataAccess.Guests.MakeReservation(receptionistViewModel.CurrentGuest.GuestID, receptionistViewModel.CurrentGuest.LastReservationDate);
                _dataAccess.Complete();
                TempData["Booking"] = bookButton;
            }
            else
            {
                TempData["Fail"] = bookButton;
            }

            
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize("IsReceptionist")]
        [HttpPost]
        public IActionResult CompleteRoom(ReceptionistViewModel receptionistViewModel)
        {
            var guests = _dataAccess.HotelRooms.GetSingleHotelRoom(receptionistViewModel.CurrentRoom.HotelRoomID).Guests;
            
            foreach (var guest in guests)
            {
                if (_dataAccess.Guests.ReservationPossible(guest.GuestID, receptionistViewModel.ReservationDate))
                {
                    _dataAccess.Guests.MakeReservation(guest.GuestID, receptionistViewModel.ReservationDate);
                }
            }

            _dataAccess.Complete();

            return RedirectToAction(nameof(Index));
        }

        [Authorize("IsReceptionist")]
        public IActionResult Reservations(ReceptionistViewModel receptionistViewModel)
        {
            if (receptionistViewModel.Reservations == null)
            {
                receptionistViewModel.Reservations = new List<Reservation>();
            }

            else
            {
                receptionistViewModel.Reservations.Clear();
            }

            var reservations = _dataAccess.Reservations.GetAllReservations();

            reservations.Sort((res1, res2) => res1.Date.CompareTo(res2.Date));

            receptionistViewModel.Reservations = reservations;

            return View(receptionistViewModel);
        }

        [Authorize("IsReceptionist")]
        public IActionResult CancelAllReservations(ReceptionistViewModel receptionistViewModel)
        {
            if (receptionistViewModel.Reservations != null)
            {
                receptionistViewModel.Reservations.Clear();
            }

            _dataAccess.Reservations.CancelAllReservations();
            _dataAccess.Complete();

            TempData["cancel"] = "CancelBtn";

            return RedirectToAction(nameof(Index));
        }

        // GET: Guests/Create
        [Authorize("IsReceptionist")]
        public IActionResult Create(ReceptionistViewModel receptionistViewModel)
        {
            receptionistViewModel.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();
            return View(receptionistViewModel);
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize("IsReceptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.Guests.AddGuest(guest);
                _dataAccess.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: Guests/Details/5
        [Authorize("IsReceptionist")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = _dataAccess.Guests.GetSingleGuest((int)id);

            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }


        // GET: Guests/Edit/5
        [Authorize("IsReceptionist")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = _dataAccess.Guests.GetSingleGuest((int)id);

            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize("IsReceptionist")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestID,FirstName,LastName,IsCheckedIn,HasEatenBreakfast,GuestType,HotelRoom")] Guest guest)
        {
            if (id != guest.GuestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    _dataAccess.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataAccess.Guests.GuestExists(guest.GuestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GuestIndex));
            }
            return View(guest);
        }

        // GET: Guests/Delete/5
        [Authorize("IsReceptionist")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var guest = _dataAccess.Guests.GetSingleGuest((int)id);

            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [Authorize("IsReceptionist")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guest = _dataAccess.Guests.GetSingleGuest((int)id);

            _dataAccess.Guests.CheckOutGuest(guest);
            _dataAccess.Complete();

            return RedirectToAction(nameof(GuestIndex));
        }
    }
}
