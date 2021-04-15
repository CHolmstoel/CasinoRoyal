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
        public IActionResult Rooms()
        {
            var waiterViewModel = new WaiterViewModel();

            waiterViewModel.CurrentRoom = _dataAccess.HotelRooms.GetSingleHotelRoom(waiterViewModel.RoomIndex);
            waiterViewModel.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();

            return View(waiterViewModel);
        }

        [HttpPost]
        public IActionResult Rooms(WaiterViewModel waiterViewModel)
        {
            waiterViewModel.CurrentRoom = _dataAccess.HotelRooms.GetSingleHotelRoom(waiterViewModel.RoomIndex);

            return View(waiterViewModel);
        }

        [HttpPost]
        public IActionResult CheckIn(WaiterViewModel waiterViewModel)
        {
            foreach (var guest in waiterViewModel.CurrentRoom.Guests)
            {
                if (guest.IsCheckedIn)
                {
                    _dataAccess.Guests.CheckInGuest(guest.GuestID);
                }
            }

            _dataAccess.Complete();

            TempData["success"] = "true";

            return RedirectToAction(nameof(Rooms));
        }
    }
}
