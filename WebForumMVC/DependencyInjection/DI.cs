using BLL.ServiceInterfaces;
using BLL.Services;
using DAL.Repositories;
using DAL.RepositoriesInterfaces;
using Microsoft.Extensions.DependencyInjection;
using WebForumMVC.Configuration.Abstractions;
using WebForumMVC.Configuration.Seeding;

namespace WebForumMVC.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<ITopicRepository, TopicRepository>();

            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();

            services.AddTransient<IDbContextSeedData, DbContextSeedData>();
            return services;
        }
    }
}
