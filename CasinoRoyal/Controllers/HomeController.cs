using CasinoRoyal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using Microsoft.AspNetCore.Authorization;

namespace CasinoRoyal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataAccessAction _dataAccsess;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccsess = new DataAccsessAction(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize("IsReceptionist")]
        public IActionResult Receptionist()
        {
            var receptionistViewModel = new ReceptionistViewModel();

            return View(receptionistViewModel);
        }

        public IActionResult KitchenStaff()
        {
            var kitchenStaffViewModel = new KitchenStaffViewModel();

            kitchenStaffViewModel.TotalGuests = _dataAccsess.Guests.GetAllGuests();
            kitchenStaffViewModel.TotalAdults = _dataAccsess.Guests.GetAllAdults();
            kitchenStaffViewModel.TotalChildren = _dataAccsess.Guests.GetAllChildren();

            return View(kitchenStaffViewModel);
        }

        [Authorize("IsWaiter")]
        public IActionResult Waiter()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
