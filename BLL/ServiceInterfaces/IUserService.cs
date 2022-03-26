using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterModel registerModel);
        Task<IdentityResult> RegisterAdmin(RegisterModel registerModel);
        Task<JwtSecurityToken> Login(LoginModel loginModel);
    }
}
