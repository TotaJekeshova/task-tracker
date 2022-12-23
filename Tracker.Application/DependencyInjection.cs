using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Tracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}