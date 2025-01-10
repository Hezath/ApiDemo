using ApiDemo.Interfaces;
using ApiDemo.Services;

namespace ApiDemo.Configuration
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
