using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace car_rental.Infrastructure.Seeds
{
    public static class DefaultRoles
    {
        public async static Task SeedAsync(RoleManager<IdentityRole> roleManager) 
        {
            if (!await roleManager.Roles.AnyAsync()) 
            {
                await roleManager.CreateAsync(new IdentityRole{ Name = ApplicationRoles.Admin.ToString()});
                await roleManager.CreateAsync(new IdentityRole{ Name = ApplicationRoles.Customer.ToString()});
            }
        }
    }
}
