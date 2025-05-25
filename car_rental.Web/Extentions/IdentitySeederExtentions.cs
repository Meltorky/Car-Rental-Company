﻿using System.Threading.Tasks;
using car_rental.Domain.Identity.Models;
using car_rental.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;

namespace car_rental.Web.Extentions
{
    public static class IdentitySeederExtentions
    {
        public static async Task IdentitySeeder(this IServiceProvider service) 
        {
            using var scope = service.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await DefaultRoles.SeedAsync(roleManager);
            await DefaultUsers.SeedAsync(userManager,roleManager);
        }
    }
}
