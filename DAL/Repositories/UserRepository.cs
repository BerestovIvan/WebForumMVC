using DAL.Entity;
using DAL.Enums;
using DAL.RepositoriesInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public UserRepository(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        public async Task<IdentityResult> Register(ApplicationUser applicationUser)
        {
            var userExists = await userManager.FindByNameAsync(applicationUser.UserName);
            if (userExists != null)
                return null;
            var result = await userManager.CreateAsync(applicationUser, applicationUser.Password);
            if (!result.Succeeded)
                return result;
            if (await roleManager.RoleExistsAsync(UserRoles.User.ToString()))
            {
                await userManager.AddToRoleAsync(applicationUser, UserRoles.User.ToString());
            }
            return result;
        }

        public async Task<IdentityResult> RegisterAdmin(ApplicationUser applicationUser)
        {
            var userExists = await userManager.FindByNameAsync(applicationUser.UserName);
            if (userExists != null)
                return null;

            var result = await userManager.CreateAsync(applicationUser, applicationUser.Password);
            if (!result.Succeeded)
                return result;

            //if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            //    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            //if (!await roleManager.RoleExistsAsync(UserRoles.User.ToString()))
            //    await roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));
            if (await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            {
                await userManager.AddToRoleAsync(applicationUser, UserRoles.Admin.ToString());
            }
            return result;
        }

        public async Task<JwtSecurityToken> Login(ApplicationUser applicationUser)
        {
            var user = await userManager.FindByNameAsync(applicationUser.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, applicationUser.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return token;
            }
            return null;
        }
    }
}
