using FrontToBack_PartialView_LoadMore.DAL;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FrontToBack_PartialView_LoadMore
{
    public static class RegisterServices
    {
        
        public static void Register(this IServiceCollection services,IConfiguration config)
        {
            services.AddControllersWithViews();
                //.AddJsonOptions(configure =>
                //{

                //});
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddSession(option =>
            {
                option.IdleTimeout=TimeSpan.FromMinutes(1);
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IBasket, BasketService>();
            services.AddIdentity<AppUser, IdentityRole>(identityOptions =>
            {
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;

                identityOptions.User.RequireUniqueEmail = true;
                identityOptions.Lockout.MaxFailedAccessAttempts = 5;
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                identityOptions.Lockout.AllowedForNewUsers = true;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

        }
    }
}
