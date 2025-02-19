using Arabytak.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        //method use to seed the user
        public static  async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(userManager.Users.Count()==0)
            {
                var user = new AppUser()
                {
                    DisplayName="Ahmed Adel",
                    Email="AboMousaOfficial@gmail.com",
                    UserName = "Ahmed.Adel",
                    PhoneNumber="011223365"
                };
                //take the user and start Create
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
            
        }
    }
}
