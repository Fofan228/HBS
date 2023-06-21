using HBS.Core.Models;

namespace HBS.Core.Common.Repositories.Interfaces;

public interface IHotelManager
{
    //TODO Предложеный вариант
    IAsyncEnumerable<HotelModel> GetHotelsByRating(Coordinate coordinate, double radius, CancellationToken cancellationToken = default);

    //TODO Предложеный вариант
    Task<HotelModel> GetNearestHotel(Coordinate coordinate, double radius,  CancellationToken cancellationToken = default);
    
    // IAsyncEnumerable<HotelModel> GetHotelsByRating(CancellationToken cancellationToken = default);

    IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius, CancellationToken cancellationToken = default);

    Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius, CancellationToken cancellationToken = default);

    // Task<HotelModel> GetNearestHotel(Coordinate coordinate, CancellationToken cancellationToken = default);
}