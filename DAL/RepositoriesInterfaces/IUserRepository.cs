using DAL.Entity;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DAL.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> Register(ApplicationUser applicationUser);
        Task<IdentityResult> RegisterAdmin(ApplicationUser applicationUser);
        Task<LoginResult> Login(ApplicationUser applicationUser);
        Task<IdentityResult> ChangePassword(ApplicationUser applicationUser);
    }
}
