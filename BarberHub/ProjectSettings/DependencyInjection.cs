using BarberHub.Repositories;
using BarberHub.Repositories.Interfaces;
using BarberHub.Services;
using BarberHub.Services.Interfaces;

namespace BarberHub.ProjectSettings
{
    public static class DependencyInjection
    {
        public static void Go(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IBarberShopRepository, BarberShopRepository>();
            builder.Services.AddScoped<IBarberShopService, BarberShopService>();
        }
    }
}
