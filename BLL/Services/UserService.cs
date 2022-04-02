using AutoMapper;
using BLL.Models;
using BLL.ServiceInterfaces;
using DAL.Entity;
using DAL.RepositoriesInterfaces;
using Microsoft.AspNetCore.Identity;
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

        public async Task<LoginResultModel> Login(LoginModel loginModel)
        {
            var loginResult =  await userRepository.Login(mapper.Map<ApplicationUser>(loginModel));
            return mapper.Map<LoginResultModel>(loginResult);
        }

    }
}
