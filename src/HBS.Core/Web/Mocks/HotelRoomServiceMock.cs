using HBS.Core.Entities;
using HBS.Core.Web.Interfaces;
using HBS.Core.Web.Models;

namespace HBS.Core.Web.Mocks;

public class HotelRoomServiceMock : IHotelRoomService
{
    public Task<ICollection<HotelRoomPricesInfo>> GetRoomsInfoAsync(IEnumerable<Coordinates> coordinates, CancellationToken token)
    {
        var result = coordinates.Select((c, i) => new HotelRoomPricesInfo(c, i, i * 2)).ToList();
        return Task.FromResult((ICollection<HotelRoomPricesInfo>)result);
    }
}