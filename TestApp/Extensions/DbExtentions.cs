using Microsoft.EntityFrameworkCore;
using TestApp.Data;

namespace TestApp.Extensions
{
    public static class DbExtentions
    {
        public static void AddDbConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(config.GetConnectionString("DbCon")));
        }
    }
}
