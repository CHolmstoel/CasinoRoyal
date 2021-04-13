using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoRoyal.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace CasinoRoyal.Data.Repositories.RepositoryInterfaces
{
    public interface IApplicationUserRepository: IRepository<ApplicationUser>
    {

        public void AddWaiterRightsToUser(UserManager<ApplicationUser> userManager, ApplicationUser receivingUser);

        public void AddReceptionistRightsToUser(UserManager<ApplicationUser> userManager, ApplicationUser receivingUser);

        public ApplicationUser GetSingleUser(int id);
    }
}
