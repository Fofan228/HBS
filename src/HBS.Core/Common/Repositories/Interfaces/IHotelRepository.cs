using HBS.Core.Models;

namespace HBS.Core.Common.Repositories.Interfaces
{
    //TODO Я тут добавил методы, как я это вижу. Если они не правильные, или вы видите другую реализацию, просто удалите их.
    public interface IHotelRepository
    {
        /// <summary>
        /// Возможно стоит добавить, чтобы отели с лучшим рейтингом искались по конкретным координатам?
        /// А не из всего списка отелей, где некоторые в Москве, а другие во Владивастоке.
        /// Или я не правильно понимаю задачу.
        /// </summary>
        IAsyncEnumerable<HotelModel> GetHotelsByRating(Coordinate coordinate, double radius);

        IAsyncEnumerable<HotelModel> GetHotelsByRating();

        IAsyncEnumerable<HotelModel> GetNearbyHotels(Coordinate coordinate, double radius);

        /// <summary>
        /// Здесь лучший отель по конкретным координатам?
        /// </summary>
        Task<HotelModel> GetBestHotel(Coordinate coordinate, double radius, CancellationToken cancellationToken);

        Task<HotelModel> GetNearestHotel(Coordinate coordinate);

        /// <summary>
        /// Здесь может тоже радиус добавить? Типо по конкретным координатам вроде конкретный отель находится же?
        /// А так будет, если в радиус по координатам попадает отель, то ближайший вернём.
        /// </summary>
        Task<HotelModel> GetNearestHotel(Coordinate coordinate, double radius, CancellationToken cancellationToken);
    }
}