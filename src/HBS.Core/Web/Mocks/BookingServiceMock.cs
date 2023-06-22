using HBS.Core.Entities;
using HBS.Core.Web.Interfaces;
using HBS.Core.Web.Models;

using Refit;

namespace HBS.Core.Web.Mocks;

public class BookingServiceMock : IBookingService
{
    public Task<ICollection<HotelRoomAvailableInfo>> GetAvailableRoomsAsync(IEnumerable<Coordinates> coordinates)
    {
        var result = coordinates.Select((c, i) => new HotelRoomAvailableInfo(c, i)).ToList();
        return Task.FromResult((ICollection<HotelRoomAvailableInfo>)result);
    }
}