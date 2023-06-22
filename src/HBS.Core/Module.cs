using HBS.Core.Services.HotelManagerService;
using HBS.Core.Web.Interfaces;
using HBS.Core.Web.Mocks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Refit;

namespace HBS.Core;

public static class Module
{
    public static IServiceCollection AddCore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        {
            services.AddScoped<IHotelManager, HotelManager>();
            services.AddRefit(configuration);
            return services;
        }
    }

    public static IServiceCollection AddRefit(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var bookingServiceConnectionString = configuration.GetConnectionString("BookingService");
        if (string.IsNullOrWhiteSpace(bookingServiceConnectionString))
            throw new NullReferenceException();

        var hotelRoomServiceConnectionString = configuration.GetConnectionString("HotelRoomService");
        if (string.IsNullOrWhiteSpace(hotelRoomServiceConnectionString))
            throw new NullReferenceException();

        // services.AddRefitClient<IBookingService>()
        //     .ConfigureHttpClient(c => c.BaseAddress = new Uri(bookingServiceConnectionString));

        services.AddScoped<IBookingService, BookingServiceMock>();

        services.AddRefitClient<IHotelRoomService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(hotelRoomServiceConnectionString));

        return services;
    }
}