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
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
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

            using (context)
            {
                var hotelRoom = new HotelRoom();
                var guest = new Guest()
                {
                    FirstName = "Jørgen",
                    LastName = "Eriksen",
                    GuestType = "Adult",
                    HasEatenBreakfast = false,
                    IsCheckedIn = false,
                    HotelRoom = hotelRoom
                };

                context.Guest.Add(guest);
                context.HotelRooms.Add(hotelRoom);
                context.SaveChanges();
            }
                
            
        }
    }
}
