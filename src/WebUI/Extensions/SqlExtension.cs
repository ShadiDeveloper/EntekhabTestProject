using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Extensions
{
    public static class SqlExtension
    {
        public static void AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration["ConnectionString"]));
        }
    }
}
