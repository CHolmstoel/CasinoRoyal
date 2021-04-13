using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasinoRoyal.Data.Entity
{
    public class Child: Guest
    {
        public Child(): base()
        {
            base.GuestType = "Child";
        }
    }
}
