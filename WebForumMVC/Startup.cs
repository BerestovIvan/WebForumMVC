using DAL.DbContext;
using DAL.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebForumMVC.DependencyInjection;
using WebForumMVC.Mapper;

namespace WebForumMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(MapperBLLAndApi), typeof(MapperBLLAndDAL));

            DI.AddDependencyInjection(services);

            services.AddDbContext<ApplicationDbContext>(options => options.
          UseSqlServer(Configuration.GetConnectionString("WebForumMVC")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
         .AddEntityFrameworkStores<ApplicationDbContext>()
         .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = Configuration["JWT:ValidAudience"],
                   ValidIssuer = Configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
               };
           });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("token");
                if (!string.IsNullOrEmpty(token))
                {
                    //context.Request.Headers.Add("Content-Type", "application/json ");
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });

            app.Use(async (context, next) =>
            {
                var userId = context.Session.GetString("UserId");
                if (!string.IsNullOrEmpty(userId))
                {
                    context.Request.Headers.Add("UserId", userId);
                }
                await next();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
