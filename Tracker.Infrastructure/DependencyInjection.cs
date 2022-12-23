using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracker.Application.Contracts.Projects;
using Tracker.Application.Contracts.Tasks;
using Tracker.Infrastructure.Persistance;
using Tracker.Infrastructure.Repositories;

namespace Tracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrackerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TrackerStorageConnectionString")));

        services.AddScoped<IChangeProjectRepository, ProjectRepository>();
        services.AddScoped<IAboutProjectRepository, ProjectRepository>();
        
        services.AddScoped<IChangeTaskRepository, TaskRepository>();
        services.AddScoped<IAboutTaskRepository, TaskRepository>();
        
        return services;
    }
}