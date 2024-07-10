using Faradid.Tracking.Application.Interfaces;
using Faradid.Tracking.Application.Interfaces.Common;
using Faradid.Tracking.Persistence.Context;
using Faradid.Tracking.Persistence.Repositories;
using Faradid.Tracking.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Faradid.Tracking.Persistence
{
    public static class PersistenceServicesRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TrackingDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("ConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }


    }
}
