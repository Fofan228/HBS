using HBS.Data.Repositories;
using HBS.Core.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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