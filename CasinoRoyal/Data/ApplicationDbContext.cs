using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoRoyal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
