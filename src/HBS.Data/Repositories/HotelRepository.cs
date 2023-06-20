using HBS.Core.Common.Repositories.Interfaces;
using HBS.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace HBS.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;

        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public IAsyncEnumerable<HotelModel> GetHotelsByRating()
        {
            return _context.Hotels
                .OrderByDescending(hotel => hotel.Rating)
                .AsAsyncEnumerable();
        }

    }
}