
namespace HBS.Core.Models
{
    public class HotelModel
    {
        public HotelModel(long id, string address, string hotelName, double rating, double longitude, double latitude)
        {
            Id = id;
            Address = address;
            HotelName = hotelName;
            Rating = rating;
            Longitude = longitude;
            Latitude = latitude;
        }

        private HotelModel() { }
        
        public long Id { get; set; }
        public string Address { get; set; } = null!;
        public string HotelName { get; set; } = null!;
        public double Rating { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}