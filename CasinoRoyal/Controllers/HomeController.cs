using CasinoRoyal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data;
using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace CasinoRoyal.Controllers
{
    public class HomeController : Controller
    {
        private IDataAccessAction _dataAccess;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccessAction(context);
        }

        public IActionResult Index()
        {
            if (User.HasClaim("Waiter", "IsWaiter"))
                return RedirectToAction("Index", "Waiter");

            if (User.HasClaim("Receptionist", "IsReceptionist"))
                return RedirectToAction("Index", "Receptionist");

            if (User.HasClaim("KitchenStaff", "IsKitchenStaff"))
                return RedirectToAction("Index", "KitchenStaff");

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
