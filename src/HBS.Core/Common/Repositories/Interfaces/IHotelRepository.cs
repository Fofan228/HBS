using HBS.Core.BusinessLogic;
using HBS.Core.Models;

namespace HBS.Core.Common.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        IAsyncEnumerable<HotelModel> OrderHotelsByRating();

        IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius);

         Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius);

         Task<HotelModel> GetNearestHotel(Coordinate coordinate);
    }
}