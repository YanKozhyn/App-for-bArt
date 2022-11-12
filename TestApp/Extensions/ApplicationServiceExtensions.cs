using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Helpers;
using TestApp.Interfaces;
using TestApp.Services;

namespace TestApp.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(config.GetConnectionString("DbCon")));

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IIncidentService, IncidentService>();

            return services;
        }
    }
}
