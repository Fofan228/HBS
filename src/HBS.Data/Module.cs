using Microsoft.Extensions.DependencyInjection;

namespace HBS.Data;

public static class Module
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        return services;
    }
}