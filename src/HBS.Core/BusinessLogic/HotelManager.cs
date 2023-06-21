using System.Runtime.CompilerServices;

using HBS.Core.Common.Repositories.Interfaces;
using HBS.Core.Models;

using Microsoft.Extensions.Logging;

namespace HBS.Core.BusinessLogic;

public class HotelManager : IHotelManager
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ILogger<HotelManager> _logger;

    public HotelManager(IHotelRepository hotelRepository, ILogger<HotelManager> logger)
    {
        _hotelRepository = hotelRepository;
        _logger = logger;
    }

    public async IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var hotels = _hotelRepository.GetNearbyHotels(coordinate, radius);
        var hotelsCount = 0;
        await foreach (var hotel in hotels.WithCancellation(cancellationToken))
        {
            yield return hotel;
            hotelsCount++;
        }

        _logger.LogInformation("return list hotels {hotelsCount} pics", hotelsCount);
    }

    public async IAsyncEnumerable<HotelModel> GetHotelsByRating(
        Coordinate coordinate, double radius,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var hotels = _hotelRepository.GetHotelsByRating(coordinate, radius);
        var hotelsCount = 0;
        await foreach (var hotel in hotels.WithCancellation(cancellationToken))
        {
            yield return hotel;
            hotelsCount++;
        }

        _logger.LogInformation("return ordered list hotels by rating {hotelsCount} pics", hotelsCount);
    }

    public async Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius,
        CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetBestHotel(coordinate, radius, cancellationToken);
        _logger.LogInformation("return best hotel {hotel}", hotel);
        return hotel;
    }

    public async Task<HotelModel> GetNearestHotel(Coordinate coordinate, double radius,
        CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetNearestHotel(coordinate, radius, cancellationToken);
        _logger.LogInformation("return nearest hotel {hotel}", hotel);
        return hotel;
    }
}