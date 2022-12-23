using AutoMapper;
using Tracker.API.Mappings;

namespace Tracker.API;

public static class DependencyInjection
{
    public static IServiceCollection SetAutomapperProfiles(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            //cfg.AddCollectionMappers();
            cfg.AddProfile(new ApiMappingProfile());
        }).CreateMapper());
        return services;
    }

}