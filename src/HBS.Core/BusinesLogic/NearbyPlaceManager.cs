using HBS.Core.Models;

namespace HBS.Core.BusinesLogic
{
    public class NearbyPlaceManager
    {
        public List<NearbyPlaceModel> GetNearbyPlaces(HotelModel hotel, double radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude))
                        .ToList();
        }

        public NearbyPlaceModel GetNearestPlace(HotelModel hotel, double radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude))
                        .First();
        }

        public List<NearbyPlaceModel> GetNearbyPlaces(double longitude, double latitude, double radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude))
                        .ToList();
        }

        public NearbyPlaceModel GetNearestPlace(double longitude, double latitude, double radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude))
                        .First();
        }
        private double DistanceBetweenObjects(double startX, double startY, double endX, double endY){
            return Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startX - endX, 2));
        }
    }
}