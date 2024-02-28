using Class11.BusinessLogic;
using Class11.DAO;
using Class13.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Class12.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddInMemoryPersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Connection"));
            });
            return services;
        }
    }
}
