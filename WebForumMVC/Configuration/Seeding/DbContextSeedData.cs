using DAL.Entity;
using DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForumMVC.Configuration.Abstractions;

namespace WebForumMVC.Configuration.Seeding
{
    public class DbContextSeedData : IDbContextSeedData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbContextSeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAdmin()
        {
            var roleName = UserRoles.Admin.ToString();
            var role = await _roleManager.FindByNameAsync(roleName);

            if(role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            }

            role = await _roleManager.FindByNameAsync(roleName);

            if (role != null)
            {
                var admin = new ApplicationUser(){UserName = "admin1@gmail.com", NormalizedUserName = "ADMIN", Email = "admin1@gmail.com", NormalizedEmail = "ADMIN1@GMAIL.COM"};

                var password = "Berestov1!";

                var checkingInDb = await _userManager.FindByNameAsync(admin.UserName);
                if (checkingInDb == null)
                {
                    await _userManager.CreateAsync(admin, password);
                    await _userManager.AddToRoleAsync(admin, roleName);
                }
            }
        }
    }
}
