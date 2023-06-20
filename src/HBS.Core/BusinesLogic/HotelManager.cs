using HBS.Core.Models;

namespace HBS.Core.BusinesLogic
{
    public class HotelManager
    {
        public List<HotelModel> GetNearbyHotels(double longitude, double latitude, double radius){
            return HotelsModel.Hotels
                        .Where(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude) < radius)
                        .OrderBy(h => h.Rating)
                        .ToList();
        }

        public HotelModel GetBestHotel(double longitude, double latitude, double radius){
            return HotelsModel.Hotels
                        .Where(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude) < radius)
                        .OrderBy(h => h.Rating)
                        .First();
        }

        public HotelModel GetNearestHotel(double longitude, double latitude){
            return HotelsModel.Hotels
                        .OrderBy(h => DistanceBetweenObjects(longitude, latitude, h.Longitude, h.Latitude))
                        .First();
        }

        private double DistanceBetweenObjects(double startX, double startY, double endX, double endY){
            return Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startX - endX, 2));
        }
    }
}