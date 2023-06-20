

namespace HBS.Core.Models
{
    public class NearbyPlaceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}