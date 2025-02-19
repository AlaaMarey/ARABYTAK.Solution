using Arabytak.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Service.Contract
{
    public interface IAuthService
    {
        Task <string> CreateTokenAsync(AppUser user,UserManager<AppUser> manager);// Method To Create Token 
    }
}
