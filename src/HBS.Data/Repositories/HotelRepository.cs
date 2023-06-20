using HBS.Core.BusinessLogic;
using HBS.Core.Common.Repositories.Interfaces;
using HBS.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace HBS.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<HotelModel> GetHotelsByRating()
        {
            return _context.Hotels
                .OrderByDescending(hotel => hotel.Rating)
                .AsAsyncEnumerable();
        }

        public IAsyncEnumerable<HotelModel> OrderHotelsByRating()
        {
            return _context.Hotels
                .OrderBy(hotel => hotel.Rating)
                .AsAsyncEnumerable();
        }

        public IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius)
        {
            var calculateDistance = (double lo, double la) =>
                Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));
            var checkRadius = (double lo, double la) => calculateDistance(lo, la) <= radius;
            return _context.Hotels
                .Where(hotel => checkRadius(hotel.Longitude, hotel.Latitude))
                .OrderBy(hotel => calculateDistance(hotel.Longitude, hotel.Latitude))
                .AsAsyncEnumerable();
        }

        public Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius)
        {
            throw new NotImplementedException();
        }

        public Task<HotelModel> GetNearestHotel(Coordinate coordinate)
        {
            // var calculateDistance = (double lo, double la) =>
            //     Math.Sqrt(Math.Pow(lo - coordinate.Longitude, 2) + Math.Pow(la - coordinate.Latitude, 2));
            // var a = await _context.Hotels;
            // var b = a.OrderBy(hotel => calculateDistance(hotel.Longitude, hotel.Latitude)).First();
            // return b;
            throw new NotImplementedException();
        }
    }
}