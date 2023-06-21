using HBS.Core.Common.Repositories.Interfaces;
using HBS.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace HBS.Data.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }

    public IAsyncEnumerable<HotelModel> GetHotelsByRating(Coordinate coordinate, double radius)
    {
        double CalculateDistance(double lo, double la)
            => Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));

        var checkRadius = (double lo, double la) => CalculateDistance(lo, la) <= radius;

        return _context.Hotels
            .Where(hotel => checkRadius(coordinate.Longitude, coordinate.Latitude))
            .OrderByDescending(hotel => hotel.Rating)
            .AsAsyncEnumerable();
    }

    public IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius)
    {
        var calculateDistance = (double lo, double la) =>
            Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));
        var checkRadius = (double lo, double la) => calculateDistance(lo, la) <= radius;
        return _context.Hotels
            .Where(hotel => checkRadius(coordinate.Longitude, coordinate.Latitude))
            .OrderBy(hotel => calculateDistance(coordinate.Longitude, coordinate.Latitude))
            .AsAsyncEnumerable();
    }

    public async Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius,
        CancellationToken cancellationToken)
    {
        double CalculateDistance(double lo, double la)
            => Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));

        var checkRadius = (double lo, double la) => CalculateDistance(lo, la) <= radius;

        return await _context.Hotels
            .Where(hotel => checkRadius(coordinate.Longitude, coordinate.Latitude))
            .OrderByDescending(hotel => hotel.Rating)
            .FirstAsync(cancellationToken);
    }

    public async Task<HotelModel> GetNearestHotel(Coordinate coordinate, double radius,
        CancellationToken cancellationToken)
    {
        var calculateDistance = (double lo, double la) =>
            Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));
        var checkRadius = (double lo, double la) => calculateDistance(lo, la) <= radius;
        return await _context.Hotels
            .Where(hotel => checkRadius(coordinate.Longitude, coordinate.Latitude))
            .OrderBy(hotel => calculateDistance(coordinate.Longitude, coordinate.Latitude))
            .FirstAsync(cancellationToken);
    }
}