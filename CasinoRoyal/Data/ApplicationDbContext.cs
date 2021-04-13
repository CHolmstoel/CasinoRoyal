using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<HotelRoom> HotelRooms { get; set; }
        DbSet<Child> Children { get; set; }
        DbSet<Adult> Adults { get; set; }
    }
}
