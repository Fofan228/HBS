using HBS.Core.Entities;

namespace HBS.Core.Web.Models;

public record HotelRoomPricesInfo(Coordinates Coordinates, decimal MinPrice, decimal MaxPrice);