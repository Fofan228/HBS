using HBS.Core.Entities;

namespace HBS.Core.Repositories.Interfaces;

public interface IHotelRepository
{
    IAsyncEnumerable<Hotel> ListHotels();
    Task<Hotel?> GetById(long id, CancellationToken token);
}