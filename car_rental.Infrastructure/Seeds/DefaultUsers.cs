using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_rental.Domain.Identity.Enums;
using car_rental.Domain.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace car_rental.Infrastructure.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            var admin = new ApplicationUser 
            {
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "@admin",
                FullName = "Admin",
            };

            if (await userManager.FindByEmailAsync(admin.Email) is null)
            {
                string password = "Ab123456+";

                var result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded && roleManager.RoleExistsAsync(ApplicationRoles.Admin.ToString()) is not null)
                    await userManager.AddToRoleAsync(admin, ApplicationRoles.Admin.ToString());
                
            }
        }
    }
}
