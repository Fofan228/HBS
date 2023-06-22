using HBS.Core.Entities;
using HBS.Core.Web.Interfaces;
using HBS.Core.Web.Models;

namespace HBS.Core.Web.Mocks;

public class BookingServiceMock : IBookingService
{
    public Task<HotelRoomAvailableInfo[]> GetAvailableRoomsAsync(IEnumerable<Coordinates> coordinates)
    {
        var result = coordinates.Select(c => new HotelRoomAvailableInfo(c, (int)(c.Latitude + c.Longitude))).ToArray();
        return Task.FromResult(result);
    }
}