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
    public class GuestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IDataAccessAction _dataAccess;
        public GuestsController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccessAction(context);
        }

        // GET: Guests
        [Authorize("IsReceptionist")]
        public async Task<IActionResult> Index()
        {
            var AllGuests = from g in _dataAccess.Guests.GetAllGuests() select g;
            return View(AllGuests);
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

            //var guest = await _context.Guest
            //    .FirstOrDefaultAsync(m => m.GuestID == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
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
        public async Task<IActionResult> Create( Guest guest)
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

        // GET: Guests/Edit/5
        [Authorize("IsReceptionist")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guest = _dataAccess.Guests.GetSingleGuest((int)id);
            //var guest = await _context.Guest.FindAsync(id);
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
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.GuestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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
            //var guest = await _context.Guest
            //    .FirstOrDefaultAsync(m => m.GuestID == id);
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
            //var guest = await _context.Guest.FindAsync(id);
            _dataAccess.Guests.CheckOutGuest(guest);
            //_context.Guest.Remove(guest);
            _dataAccess.Complete();
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
            return _context.Guest.Any(e => e.GuestID == id);
        }
    }
}
