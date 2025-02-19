using Arabytak.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository.Data.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        //use this way( when we need to create object from This Db it open connection with DataBase)
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options) 
        {


        }
        //not need to create DbSet=>Becouse it inhertance from package
        // not need override to OnModelCreating =>Becouse Dont have FluentApi
        
            
    }

}

