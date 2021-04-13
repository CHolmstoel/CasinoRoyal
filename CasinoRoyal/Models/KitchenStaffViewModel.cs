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
        [Display(Name = "Guests")]
        public int TotalGuests { get; set; }

        [Display(Name = "Adults")]
        public int TotalAdults { get; set; }

        [Display(Name = "Children")]
        public int TotalChildren { get; set; }

        [Display(Name = "Adults Checked In")]
        public int AdultsCheckedIn { get; set; }

        [Display(Name = "Children Checked In")]
        public int ChildrenCheckedIn { get; set; }

        [Display(Name = "Not Checked In")]
        public int TotalNotCheckedIn { get; set; }

        [Display(Name = "Adults Not Checked In")]
        public int AdultsNotCheckedIn { get; set; }

        [Display(Name = "Children Not Checked In")]
        public int ChildrenNotCheckedIn { get; set; }
    }
}
