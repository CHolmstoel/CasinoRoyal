using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        [Authorize("IsWaiter")] // commented out during testing
        [HttpGet]
        public IActionResult Index(int index)
        {
            var waiterViewModel = new WaiterViewModel();

            waiterViewModel.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();

            if (TempData["Room Index"] != null)
            {
                waiterViewModel.RoomIndex = (int) TempData["Room Index"];
            }

            return View(waiterViewModel);
        }

        [Authorize("IsWaiter")]
        [HttpPost]
        public IActionResult Index(WaiterViewModel waiterViewModel)
        {


            if ((int)waiterViewModel.DisplayRoomNumbers.SelectedValue > 0)
            {
                waiterViewModel.Guests = _dataAccess.HotelRooms.GetReservationsForRoom(waiterViewModel.RoomIndex);
            }
            else
            {
                TempData["check"] = "false";
            }

            waiterViewModel.NumberOfRooms = _dataAccess.HotelRooms.GetNumberOfHotelRooms();

            return View(waiterViewModel);
        }

        [Authorize("IsWaiter")]
        [HttpPost]
        public IActionResult CheckIn(WaiterViewModel waiterViewModel, string btn)
        {
            foreach (var guest in waiterViewModel.Guests)
            {
                if (guest.GuestID == int.Parse(btn))
                {
                    _dataAccess.Guests.CheckIn(guest.GuestID);
                    _dataAccess.Complete();
                }
            }

            TempData["Room Index"] = waiterViewModel.RoomIndex;
            TempData["success"] = "true";

            return RedirectToAction(nameof(Index));
        }

        [Authorize("IsWaiter")]
        public IActionResult Checkout()
        {
            _dataAccess.Guests.CheckOutAll();
            _dataAccess.Complete();

            TempData["CheckedOut"] = "true";

            return RedirectToAction(nameof(Index));
        }
    }
}
