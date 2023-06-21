using HBS.Data.Repositories;
using HBS.Core.Common.Repositories.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HBS.Data;

public static class Module
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HotelContext>(options => HotelContext.Configure(options, configuration));
        services.AddScoped<IHotelRepository, HotelRepository>();
        return services;
    }
}