using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Entity
{
    public class Adult:Guest
    {
        public Adult(): base()
        {
            base.GuestType = "Adult";
        }
    }
}
