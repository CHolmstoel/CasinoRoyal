using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;
using CasinoRoyal.Data.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Identity;

namespace CasinoRoyal.Data.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddWaiterRightsToUser(UserManager<ApplicationUser> userManager, ApplicationUser receivingUser)
        {
            if (userManager.FindByNameAsync(receivingUser.Email).Result != null)
            {
                userManager.AddClaimAsync(receivingUser, new Claim("Waiter", "IsWaiter"));
            }
            
        }

        public void AddReceptionistRightsToUser(UserManager<ApplicationUser> userManager, ApplicationUser receivingUser)
        {
            if (userManager.FindByNameAsync(receivingUser.Email).Result != null)
            {
                userManager.AddClaimAsync(receivingUser, new Claim("Receptionist", "IsReceptionist"));
            }
        }
    }
}
