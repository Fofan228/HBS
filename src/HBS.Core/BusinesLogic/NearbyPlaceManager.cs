using HBS.Core.Models;

namespace HBS.Core.BusinesLogic
{
    public class NearbyPlaceManager
    {
        public List<NearbyPlaceModel> GetNearbyPlaces(HotelModel hotel, float radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude))
                        .ToList();
        }

        public NearbyPlaceModel GetNearestPlace(HotelModel hotel, float radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(hotel.Longitude, hotel.Latitude, p.Longitude, p.Latitude))
                        .First();
        }

        public List<NearbyPlaceModel> GetNearbyPlaces(float longitude, float latitude, float radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude))
                        .ToList();
        }

        public NearbyPlaceModel GetNearestPlace(float longitude, float latitude, float radius){
            return NearbyPlacesModel.NearbyPlaces
                        .Where(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude) < radius)
                        .OrderBy(p => DistanceBetweenObjects(longitude, latitude, p.Longitude, p.Latitude))
                        .First();
        }
        private float DistanceBetweenObjects(float startX, float startY, float endX, float endY){
            return MathF.Sqrt(MathF.Pow(startX - endX, 2) + MathF.Pow(startX - endX, 2));
        }
    }
}