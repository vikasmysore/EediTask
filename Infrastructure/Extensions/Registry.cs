using Infrastructure.DBContext;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class Registry
    {
        public static IServiceCollection RegisterInfrastructureExtensions(this IServiceCollection services)
        {

            services.AddScoped<IImproveRepository, ImproveRepository>();

            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ImproveDb"));

            return services;
        }
    }
}
