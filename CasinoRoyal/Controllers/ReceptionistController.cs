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
        public IActionResult Complete(ReceptionistViewModel receptionistViewModel, string bookButton)
        {
            _dataAccess.Guests.MakeReservation(receptionistViewModel.CurrentGuest.GuestID, receptionistViewModel.CurrentGuest.LastReservationDate);
            _dataAccess.Complete();

            TempData["Booking"] = bookButton;
            
            return RedirectToAction(nameof(Index));
        }
    }
}
