using HBS.Core.Entities;
using HBS.Core.Web.Models;

using Refit;

namespace HBS.Core.Web.Interfaces;

public interface IBookingService
{
    [Get("/availableRooms")]
    Task<ICollection<HotelRoomAvailableInfo>> GetAvailableRoomsAsync(
        IEnumerable<Coordinates> coordinates,
        CancellationToken token);
}