using HBS.Core.Entities;
using HBS.Core.Web.Models;

using Refit;

namespace HBS.Core.Web.Interfaces;

public interface IHotelRoomService
{
    [Get("/roomsInfo")]
    Task<ICollection<HotelRoomPricesInfo>> GetRoomsInfoAsync(
        IEnumerable<Coordinates> coordinates,
        CancellationToken token);
}