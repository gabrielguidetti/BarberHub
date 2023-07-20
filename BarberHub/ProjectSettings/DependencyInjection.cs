using BarberHub.Repositories;
using BarberHub.Repositories.Interfaces;

namespace BarberHub.ProjectSettings
{
    public static class DependencyInjection
    {
        public static void Go(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
