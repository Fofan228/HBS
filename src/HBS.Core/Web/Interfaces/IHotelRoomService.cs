using HBS.Core.Entities;
using HBS.Core.Web.Models;

using Refit;

namespace HBS.Core.Web.Interfaces;

public interface IHotelRoomService
{
    [Get("/Hotels/all")]
    Task<HotelsRoomModel> GetHotels();

    [Get("/Hotels")]
    Task<HotelRoomModel?> GetHotel([Query] double hotelLongitude, [Query] double hotelLatitude);
}