namespace HBS.Core.Models
{
    public class HotelModel
    {
        public HotelModel(long id, string address, string hotelName, double rating, Coordinate coordinate)
        {
            Id = id;
            Address = address;
            HotelName = hotelName;
            Rating = rating;
            Coordinate = coordinate;
        }

        private HotelModel() { }

        public long Id { get; set; }
        public string Address { get; set; } = null!;
        public string HotelName { get; set; } = null!;
        public double Rating { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}