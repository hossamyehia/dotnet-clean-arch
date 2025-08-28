using System;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;

public static class DependencyInjection
{

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        // register all the mapping configurations
        config.Scan(typeof(DependencyInjection).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
