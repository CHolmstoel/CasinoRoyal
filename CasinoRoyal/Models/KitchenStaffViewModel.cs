using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Models
{
    public class KitchenStaffViewModel
    {
        public int TotalGuests { get; set; }

        public int TotalAdults { get; set; }
        public int TotalChildren { get; set; }
        public int TotalNotCheckedIn { get; set; }
        public int AdultsCheckedIn { get; set; }
        public int ChildrenCheckedIn { get; set; }

    }
}
