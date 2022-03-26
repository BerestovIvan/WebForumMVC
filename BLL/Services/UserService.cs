using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using DAL.Entity;
using DAL.RepositoriesInterfaces;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository userRepository;
        readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Register(RegisterModel registerModel)
        {
            return await userRepository.Register(mapper.Map<ApplicationUser>(registerModel));
        }

        public async Task<IdentityResult> RegisterAdmin(RegisterModel registerModel)
        {
            return await userRepository.RegisterAdmin(mapper.Map<ApplicationUser>(registerModel));
        }

        public async Task<JwtSecurityToken> Login(LoginModel loginModel)
        {
            return await userRepository.Login(mapper.Map<ApplicationUser>(loginModel));
        }

    }
}
