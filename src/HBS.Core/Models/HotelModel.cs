using HBS.Core.Entities;
using HBS.Core.Web.Models;

namespace HBS.Core.Models;

public class HotelModel
{
    public HotelModel(long id, double rating, Coordinates coordinates, string name, string address, string shortDescription, string longDescription, string[] photos, int roomsAvailable, decimal maxPrice, decimal minPrice)
    {
        Id = id;
        Rating = rating;
        Coordinates = coordinates;
        Name = name;
        Address = address;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Photos = photos;
        RoomsAvailable = roomsAvailable;
        MaxPrice = maxPrice;
        MinPrice = minPrice;
    }
    #region From Database

    public long Id { get; set; }
    public double Rating { get; set; }
    public Coordinates Coordinates { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string[] Photos { get; set; }

    #endregion

    #region From HotelRoomService

    public int RoomsAvailable { get; set; }
    public decimal MaxPrice { get; set; }
    public decimal MinPrice { get; set; }

    #endregion

    public static HotelModel Create(Hotel hotel, HotelRoomPricesInfo prices, HotelRoomAvailableInfo rooms)
    {
        return new(
            hotel.Id,
            hotel.Rating,
            hotel.Coordinates,
            hotel.Name,
            hotel.Address,
            hotel.ShortDescription,
            hotel.LongDescription,
            hotel.Photos,
            rooms.RoomsAvailable,
            prices.MaxPrice,
            prices.MinPrice);
    }
}