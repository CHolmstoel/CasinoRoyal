using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CasinoRoyal.Models
{
    public class KitchenStaffViewModel
    {
        [Display(Name = "Total")]
        public int TotalGuests
        {
            get { return TotalChildren + TotalAdults; }
        }

        [Display(Name = "Total")]
        public int TotalNotCheckedIn
        {
            get { return ChildrenNotCheckedIn + AdultsNotCheckedIn; }
        }

        [Display(Name = "Adults")]
        public int TotalAdults { get; set; }

        [Display(Name = "Children")]
        public int TotalChildren { get; set; }

        [Display(Name = "Adults")]
        public int AdultsCheckedIn { get; set; }

        [Display(Name = "Children")]
        public int ChildrenCheckedIn { get; set; }

        [Display(Name = "Adults")]
        public int AdultsNotCheckedIn { get; set; }

        [Display(Name = "Children")]
        public int ChildrenNotCheckedIn { get; set; }
    }
}
