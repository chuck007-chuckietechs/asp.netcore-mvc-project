using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace NBDPrototype.Data
{
    public class ApplicationSeedData
    {
        public static async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            //Create Roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Manager", "Designer", "Worker" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Create Users
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            if (userManager.FindByEmailAsync("keri@nbd.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "keri@nbd.com",
                    Email = "keri@nbd.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Designer").Wait();
                }
            }
            if (userManager.FindByEmailAsync("tamara@nbd.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "tamara@nbd.com",
                    Email = "tamara@outlook.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Designer").Wait();
                }
            }
            if (userManager.FindByEmailAsync("cheryl@nbd.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "cheryl@nbd.com",
                    Email = "cheryl@nbd.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "password").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
        }
    }
}
