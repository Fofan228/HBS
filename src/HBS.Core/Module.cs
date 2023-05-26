using Microsoft.Extensions.DependencyInjection;

namespace HBS.Core;

public static class Module
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}