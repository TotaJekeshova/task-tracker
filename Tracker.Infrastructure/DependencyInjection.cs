using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Infrastructure.Persistance;

namespace Tracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrackerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TrackerStorageConnectionString")));

        return services;
    }
}