using Application.IServices;
using Application.Services;
using Domain.IRepositories;
using Infrastructure.Repositories;

namespace WebUI.Extensions
{
    public static class RegisterExtenstion
    {
        public static void AddRegister(this IServiceCollection services)
        {
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ISalaryDapperRepository, SalaryDapperRepository>();
        }
    }
}
