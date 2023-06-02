using HBS.Core.Models;

namespace HBS.Core.BusinesLogic
{
    public class HotelManager
    {
        public List<HotelModel> GetNearbyHotels(float longitude, float latitude, float radius){
            return HotelsModel.Hotels
                        .Where(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude) < radius)
                        .OrderBy(h => h.Rating)
                        .ToList();
        }

        public HotelModel GetBestHotel(float longitude, float latitude, float radius){
            return HotelsModel.Hotels
                        .Where(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude) < radius)
                        .OrderBy(h => h.Rating)
                        .First();
        }

        public HotelModel GetNearestHotel(float longitude, float latitude){
            return HotelsModel.Hotels
                        .OrderBy(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude))
                        .First();
        }

        private float DistanceBetweenObjects(float startX, float startY, float endX, float endY){
            return MathF.Sqrt(MathF.Pow(startX - endX, 2) + MathF.Pow(startX - endX, 2));
        }
    }
}