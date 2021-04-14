using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Models;

namespace CasinoRoyal.Controllers
{
    public class WaiterController : Controller
    {
        private IDataAccessAction _dataAccess;
        private readonly ApplicationDbContext _context;

        public WaiterController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccessAction(context);
        }

        //[Authorize("IsWaiter")] // commented out during testing
        [HttpGet]
        public IActionResult Waiter()
        {
            var waiterViewModel = new WaiterViewModel(_dataAccess);
            waiterViewModel.HotelRooms = _dataAccess.HotelRooms.GetAllHotelRooms();

            waiterViewModel.CurrentRoom = waiterViewModel.HotelRooms[waiterViewModel.RoomIndex];
            waiterViewModel.NumberOfRooms = waiterViewModel.HotelRooms.Count;

            return View(waiterViewModel);
        }

        [HttpPost]
        public IActionResult Waiter(WaiterViewModel waiterViewModel)
        {
            waiterViewModel.Guests = _dataAccess.HotelRooms.GetSingleHotelRoom(waiterViewModel.RoomIndex).Guests;
            waiterViewModel.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();
            waiterViewModel.DataAccess = _dataAccess;

            return View(waiterViewModel);
        }

        [HttpPost]
        public IActionResult CheckIn(List<Guest> guests)
        {
            foreach (var guest in guests)
            {
                if (guest.IsCheckedIn)
                {
                    _dataAccess.Guests.CheckInGuest(guest.GuestID);
                }
            }

            _dataAccess.Complete();

            TempData["success"] = "true";

            return RedirectToAction(nameof(Waiter));
        }
    }
}
