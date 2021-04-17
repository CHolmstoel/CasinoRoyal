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

        public IActionResult Book(string bookButton)
        {
            var receptionistViewModel = new ReceptionistViewModel();

            receptionistViewModel.CurrentRoom = _dataAccess.HotelRooms.GetSingleHotelRoom(int.Parse(bookButton));

            return View(receptionistViewModel);
        }

        [HttpPost]
        public IActionResult CompleteGuest(ReceptionistViewModel receptionistViewModel, string bookButton)
        {
            //Hvis reservationen ligger idag, tjek for dette, ellers ikke
            if(_dataAccess.Guests.ReservationPossible(receptionistViewModel.CurrentGuest.GuestID))
            { 
                _dataAccess.Guests.MakeReservation(receptionistViewModel.CurrentGuest.GuestID, receptionistViewModel.CurrentGuest.LastReservationDate);
                _dataAccess.Complete();
                TempData["Booking"] = bookButton.ToString();
            }
            else
            {
                TempData["Booking"] = "Failed";
            }

            
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CompleteRoom(ReceptionistViewModel receptionistViewModel)
        {
            var guests = _dataAccess.HotelRooms.GetSingleHotelRoom(receptionistViewModel.CurrentRoom.HotelRoomID).Guests;
            
            foreach (var guest in guests)
            {
                _dataAccess.Guests.MakeReservation(guest.GuestID, receptionistViewModel.ReservationDate);   
            }

            _dataAccess.Complete();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Reservations(ReceptionistViewModel receptionistViewModel)
        {
            if (receptionistViewModel.GuestsWithReservations == null)
            {
                receptionistViewModel.GuestsWithReservations = new List<Guest>();
            }

            else
            {
                receptionistViewModel.GuestsWithReservations.Clear();
            }

            var reservations = _dataAccess.Reservations.GetAllReservations();

            foreach (var reservation in reservations)
            {
                foreach (var guest in reservation.Guests)
                {
                    receptionistViewModel.GuestsWithReservations.Add(guest);
                }
            }

            return View(receptionistViewModel);
        }

        [Authorize("IsReceptionist")]
        public IActionResult CancelAllReservations(ReceptionistViewModel receptionistViewModel)
        {
            if (receptionistViewModel.GuestsWithReservations != null)
            {
                receptionistViewModel.GuestsWithReservations.Clear();
            }

            _dataAccess.Reservations.CancelAllReservations();
            _dataAccess.Complete();

            return RedirectToAction(nameof(Index));
        }

        // GET: Guests/Create
        [Authorize("IsReceptionist")]
        public IActionResult Create(ReceptionistViewModel receptionistViewModel)
        {
            //var AllRooms = from r in _dataAccess.HotelRooms.GetAllHotelRooms() select r;
            //var AllRooms = new WaiterViewModel();
            //AllRooms.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();
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
                //_context.Add(guest);
                //await _context.SaveChangesAsync();
                _dataAccess.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }
    }
}
