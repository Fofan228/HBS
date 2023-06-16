using HBS.Core.Models;

namespace HBS.Core.Common.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        IAsyncEnumerable<HotelModel> GetHotelsByRating();

        IAsyncEnumerable<NearbyPlaceModel> GetRecommendedPlaces(long longitude, long latitude);
    }
}