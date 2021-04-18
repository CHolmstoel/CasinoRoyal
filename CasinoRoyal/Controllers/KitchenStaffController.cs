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
    public class KitchenStaffController : Controller
    {
        private IDataAccessAction _dataAccess;
        private readonly ApplicationDbContext _context;

        public KitchenStaffController(ApplicationDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccessAction(context);
        }

        [Authorize("isKitchenStaff")]
        public IActionResult Index()
        {
            var kitchenStaffViewModel = GetKitchenStaffInformationFromDb();

            return View(kitchenStaffViewModel);
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
