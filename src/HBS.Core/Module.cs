using HBS.Core.Common.Repositories.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace HBS.Core;

public static class Module
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
    
    public static IHotelManager AddCore(this IHotelManager hotelManager)
    {
        return hotelManager;
    }
    
}