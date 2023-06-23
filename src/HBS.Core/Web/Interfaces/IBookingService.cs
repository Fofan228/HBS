using HBS.Core.Entities;
using HBS.Core.Web.Models;

using Refit;

namespace HBS.Core.Web.Interfaces;

public interface IBookingService
{
    [Get("/all/available/rooms")]
    Task<HotelRoomAvailableInfo[]> GetAllAvailableRoomsAsync();

    [Get("/available/rooms")]
    Task<HotelRoomAvailableInfo?> GetAvailableRoomsAsync([Query] double longitude, [Query] double latitude);
}