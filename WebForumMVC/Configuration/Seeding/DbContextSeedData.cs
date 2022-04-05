using BLL.Exceptions;
using BLL.ServiceInterfaces;
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
        private readonly IUserService userService;

        public DbContextSeedData(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task Create()
        {
            var result = await userService.RegisterAdmin(
                new BLL.Models.RegisterModel { Email = "admin1@gmail.com", Password = "Berestov1!" });
            if(result != null)
            {
                if (!result.Succeeded)
                    throw new CantCreateAdminException("Admin creation exception");
                result = await userService.RegisterAdmin(
               new BLL.Models.RegisterModel { Email = "admin2@gmail.com", Password = "Berestov1!" });
                if (!result.Succeeded)
                    throw new CantCreateAdminException("Admin creation exception");

                result = await userService.Register(
                new BLL.Models.RegisterModel { Email = "user1@gmail.com", Password = "Berestov123!" });
                if (!result.Succeeded)
                    throw new UserCreationException("User creation exception");
                result = await userService.RegisterAdmin(
               new BLL.Models.RegisterModel { Email = "user2@gmail.com", Password = "Berestov12!" });
                if (!result.Succeeded)
                    throw new UserCreationException("User creation exception");
            }
           
        }
    }
}
