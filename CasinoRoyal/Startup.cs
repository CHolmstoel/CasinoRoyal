using CasinoRoyal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;

namespace CasinoRoyal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(

                    Configuration.GetConnectionString("EmilConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsWaiter",
                    policyBuilder => policyBuilder
                        .RequireClaim("Waiter"));

                options.AddPolicy("IsReceptionist",
                    policyBuilder => policyBuilder
                        .RequireClaim("Receptionist"));

                options.AddPolicy("isKitchenStaff",
                    policyBuilder => policyBuilder
                        .RequireClaim("KitchenStaff"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            SeedUsers(userManager, context); // Added for seeding
            SeedRoomAndResidents(context); //Added for seeding
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }

        public static void SeedRoomAndResidents(ApplicationDbContext context)
        {
            using (context)
            {
                ApplicationDbContext conText = context;
                IDataAccessAction dataAccess = new DataAccessAction(conText);

                //======================================================================= Guest & Room id 1
                if (dataAccess.HotelRooms.GetSingleHotelRoom(1) == null && dataAccess.Guests.GetSingleGuest(1) == null)
                {
                    var hotelRoom = new HotelRoom();
                    conText.HotelRooms.Add(hotelRoom);
                    conText.SaveChanges();

                    var guest = new Guest()
                    {
                        FirstName = "Mogens",
                        LastName = "Eberhart",
                        GuestType = "Adult",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 1,
                    };
                    conText.Guest.Add(guest);
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(1);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(1));
                    conText.SaveChanges();
                }

                //======================================================================= Guest id 2 added to room id 1
                if (dataAccess.Guests.GetSingleGuest(2) == null)
                {

                    var guest = new Guest()
                    {
                        FirstName = "Poul",
                        LastName = "Eberhart",
                        GuestType = "Child",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 1
                    };
                    conText.Guest.Add(guest);
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(1);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(2));
                    conText.SaveChanges();
                }

                //======================================================================= Guest 3 & Room id 2
                if (dataAccess.HotelRooms.GetSingleHotelRoom(2) == null && dataAccess.Guests.GetSingleGuest(3) == null)
                {
                    var hotelRoom = new HotelRoom();
                    conText.HotelRooms.Add(hotelRoom);
                    conText.SaveChanges();

                    var guest = new Guest()
                    {
                        FirstName = "Einar",
                        LastName = "Palsgaard",
                        GuestType = "Adult",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 2
                    };
                    conText.Guest.Add(guest);
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(2);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(3));
                    conText.SaveChanges();
                }

                //======================================================================= Guest 4 & Room id 3
                if (dataAccess.HotelRooms.GetSingleHotelRoom(3) == null && dataAccess.Guests.GetSingleGuest(4) == null)
                {
                    var hotelRoom = new HotelRoom();
                    conText.HotelRooms.Add(hotelRoom);
                    conText.SaveChanges();

                    var guest = new Guest()
                    {
                        FirstName = "Nicki",
                        LastName = "Minaj",
                        GuestType = "Adult",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 3
                    };
                    conText.Guest.Add(guest);
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(3);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(4));
                    conText.SaveChanges();
                }

                //======================================================================= Guest id 5 added to room id 3
                if (dataAccess.Guests.GetSingleGuest(5) == null)
                {

                    var guest = new Guest()
                    {
                        FirstName = "Junior",
                        LastName = "Minaj",
                        GuestType = "Child",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 3,
                    };
                    conText.Guest.Add(guest);
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(3);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(5));
                    conText.SaveChanges();
                }

                //======================================================================= Guest id 6+7 added to room id 2
                if (dataAccess.Guests.GetSingleGuest(6) == null && dataAccess.Guests.GetSingleGuest(7) ==null)
                {
                    List<Guest> guests = new List<Guest>
                    {
                        new Guest()
                        {
                        FirstName = "Nougi",
                        LastName = "Senior",
                        GuestType = "Adult",
                        MadeReservation = false,
                        CheckedIn = false,
                        HotelRoomID = 2
                        },
                        new Guest()
                        {
                            FirstName = "Nougi",
                            LastName = "Junior",
                            GuestType = "Child",
                            MadeReservation = false,
                            CheckedIn = false,
                            HotelRoomID = 2
                        }
                };

                    foreach (var guest in guests)
                    { 
                        conText.Guest.Add(guest);
                    }
                    
                    conText.SaveChanges();

                    var guestRoom = dataAccess.HotelRooms.GetSingleHotelRoom(2);
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(6));
                    guestRoom.Guests.Add(dataAccess.Guests.GetSingleGuest(7));
                    conText.SaveChanges();
                }

                //=======================================================================Adding empty rooms id 4 - 15
                if (dataAccess.HotelRooms.GetSingleHotelRoom(4) == null)
                {
                    var emptyRooms = new List<HotelRoom>
                    {
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        },
                        new HotelRoom()
                        {
                            Guests = new List<Guest>()
                        }
                    };

                    foreach (var room in emptyRooms)
                    {
                        conText.HotelRooms.Add(room);
                    }

                    conText.SaveChanges();
                }

            }
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            const bool emailConfirmed = true;

            const string kitchenUserEmail = "Kitchen@kitchen.com";
            const string kitchenPassword = "Sommer25!";
            const string kitchenUserCell = "20212223";
            const string kitchenUserName = "Poul Poulsen";

           
                if (userManager.FindByNameAsync(kitchenUserEmail).Result == null)
                {
                    var user1 = new ApplicationUser();
                    user1.UserName = kitchenUserEmail;
                    user1.Email = kitchenUserEmail;
                    user1.EmailConfirmed = emailConfirmed;
                    user1.PhoneNumber = kitchenUserCell;
                    user1.Name = kitchenUserName;

                    IdentityResult result = userManager.CreateAsync(user1, kitchenPassword).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddClaimAsync(user1, new Claim("KitchenStaff", "IsKitchenStaff")).Wait();
                    }
                    
                }
            
            

            const string receptionUserEmail = "reception@reception.com";
            const string receptionPassword = "Sommer25!";
            const string receptionUserCell = "20212223";
            const string receptionUserName = "Knud Poulsen";

           
                if (userManager.FindByNameAsync(receptionUserEmail).Result == null)
                {
                    var user2 = new ApplicationUser();
                    user2.UserName = receptionUserEmail;
                    user2.Email = receptionUserEmail;
                    user2.EmailConfirmed = emailConfirmed;
                    user2.PhoneNumber = receptionUserCell;
                    user2.Name = receptionUserName;

                    IdentityResult result = userManager.CreateAsync(user2, receptionPassword).Result;
                    

                    if (result.Succeeded) //Add claim to user
                    {
                        userManager.AddClaimAsync(user2, new Claim("Receptionist", "IsReceptionist")).Wait();
                    }
                    
                }
            
            

            const string waiterUserEmail = "waiter@waiter.com";
            const string waiterPassword = "Sommer25!";
            const string waiterUserCell = "20212223";
            const string waiterUserName = "Yrsa Poulsen";

                if (userManager.FindByNameAsync(waiterUserEmail).Result == null)
                {
                    var user3 = new ApplicationUser();
                    user3.UserName = waiterUserEmail;
                    user3.Email = waiterUserEmail;
                    user3.EmailConfirmed = emailConfirmed;
                    user3.PhoneNumber = waiterUserCell;
                    user3.Name = waiterUserName;

                    IdentityResult result = userManager.CreateAsync(user3, waiterPassword).Result;

                    if (result.Succeeded) //Add claim to user
                    {
                        userManager.AddClaimAsync(user3, new Claim("Waiter", "IsWaiter")).Wait();
                    }
                    
                }
                
        }
    }
}
