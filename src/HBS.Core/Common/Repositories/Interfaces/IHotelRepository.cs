using HBS.Core.Models;

namespace HBS.Core.Common.Repositories.Interfaces;

public interface IHotelRepository
{
    IAsyncEnumerable<HotelModel> GetHotelsByRating(Coordinate coordinate, double radius);

    IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius);

    Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius, CancellationToken cancellationToken);

    Task<HotelModel> GetNearestHotel(Coordinate coordinate, double radius, CancellationToken cancellationToken);
}