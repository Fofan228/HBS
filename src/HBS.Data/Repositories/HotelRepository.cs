using HBS.Core.Entities;
using HBS.Core.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace HBS.Data.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }

    public async Task<Hotel?> GetById(long id, CancellationToken token)
    {
        return await _context.Hotels.Where(h => h.Id == id).FirstOrDefaultAsync(token);
    }

    public IAsyncEnumerable<Hotel> ListHotels()
    {
        return _context.Hotels.AsAsyncEnumerable();
    }
}