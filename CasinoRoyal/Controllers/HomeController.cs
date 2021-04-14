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
            return View();
        }

        //[Authorize("IsReceptionist")]
        //public IActionResult Receptionist()
        //{
        //    var receptionistViewModel = new ReceptionistViewModel();

        //    return View(receptionistViewModel);
        //}

        public IActionResult KitchenStaff()
        {
            var kitchenStaffViewModel = GetKitchenStaffInformationFromDb();

            return View(kitchenStaffViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public KitchenStaffViewModel GetKitchenStaffInformationFromDb()
        {
            var kitchenStaffViewModel = new KitchenStaffViewModel();

            kitchenStaffViewModel.TotalAdults = _dataAccess.Guests.GetAllAdults();
            kitchenStaffViewModel.TotalChildren = _dataAccess.Guests.GetAllChildren();

            kitchenStaffViewModel.AdultsCheckedIn = _dataAccess.Guests.GetAllAdultsCheckedIn();
            kitchenStaffViewModel.ChildrenCheckedIn = _dataAccess.Guests.GetAllChildrenCheckedIn();

            kitchenStaffViewModel.AdultsNotCheckedIn = _dataAccess.Guests.GetAllAdultsNotCheckedIn();
            kitchenStaffViewModel.ChildrenNotCheckedIn = _dataAccess.Guests.GetAllChildrenNotCheckedIn();

            return kitchenStaffViewModel;
        }

    }
}
