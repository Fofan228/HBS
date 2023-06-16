using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HBS.Core.Models;

namespace HBS.Data.Repositories
{
    public class HotelRepository
    {
        private readonly HotelContext _context;

        public HotelRepository()
        {
            _context = new HotelContext();
        }

        public List<HotelModel> GetHotelsByRating(float minRating)
        {
            return _context.Hotels
                .Where(hotel => hotel.Rating >= minRating)
                .ToList();
        }

        public List<NearbyPlaceModel> GetRecommendedPlaces(long longitude, long latitude)
        {
            return _context.NearbyPlaces
                .Where(place => place.Longitude == longitude && place.Latitude == latitude)
                .ToList();
        }
    }
}