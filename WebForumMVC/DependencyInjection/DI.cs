using BLL.ServiceInterfaces;
using BLL.Services;
using DAL.Repositories;
using DAL.RepositoriesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace WebForumMVC.DependencyInjection
{
    public static class DI
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
