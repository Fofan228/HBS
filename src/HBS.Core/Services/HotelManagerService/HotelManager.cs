using System.Runtime.CompilerServices;

using Dumpify;

using HBS.Core.Entities;
using HBS.Core.Models;
using HBS.Core.Repositories.Interfaces;
using HBS.Core.Web.Interfaces;

using Microsoft.Extensions.Logging;

namespace HBS.Core.Services.HotelManagerService;

public class HotelManager : IHotelManager
{
    private readonly IHotelRepository _hotelRepository;
    private readonly ILogger<HotelManager> _logger;
    private readonly IBookingService _bookingService;
    private readonly IHotelRoomService _hotelRoomService;

    public HotelManager(
        IHotelRepository hotelRepository,
        ILogger<HotelManager> logger,
        IBookingService bookingService,
        IHotelRoomService hotelRoomService)
    {
        _hotelRepository = hotelRepository;
        _logger = logger;
        _bookingService = bookingService;
        _hotelRoomService = hotelRoomService;
    }

    public async Task<HotelModel?> GetByIdAsync(long id, CancellationToken token)
    {
        var hotel = await _hotelRepository.GetById(id, token);
        if (hotel is null) return null;

        var roomsAvailable = (await _bookingService.GetAvailableRoomsAsync(new[] { hotel.Coordinates }, token))
            .FirstOrDefault();
        if (roomsAvailable is null) return null;


        var roomsInfo = (await _hotelRoomService.GetRoomsInfoAsync(new[] { hotel.Coordinates }, token))
            .FirstOrDefault();
        if (roomsInfo is null) return null;

        var hotelModel = new HotelModel(
            hotel.Id,
            hotel.Rating,
            hotel.Coordinates,
            hotel.Name,
            hotel.Address,
            hotel.ShortDescription,
            hotel.LongDescription,
            hotel.Photos,
            roomsAvailable.RoomsAvailable,
            roomsInfo.MaxPrice,
            roomsInfo.MinPrice);

        _logger.LogInformation("Hotel with {id} was found\n{hotel}", id, hotelModel.DumpText());

        return hotelModel;
    }

    public async Task<IEnumerable<HotelModel>> ListHotelsAsync(
        HotelOrdering order,
        CancellationToken token)
    {
        var hotels = await _hotelRepository.ListHotels().ToListAsync(token);
        var hotelCoordinates = hotels.ConvertAll(h => h.Coordinates);
        var roomsAvailable = (await _bookingService.GetAvailableRoomsAsync(hotelCoordinates, token))
            .ToDictionary(r => r.Coordinates, r => r);
        var roomsInfo = (await _hotelRoomService.GetRoomsInfoAsync(hotelCoordinates, token))
            .ToDictionary(r => r.Coordinates, r => r);

        var hotelModels = hotels.Select(hotel => new HotelModel(
            hotel.Id,
            hotel.Rating,
            hotel.Coordinates,
            hotel.Name,
            hotel.Address,
            hotel.ShortDescription,
            hotel.LongDescription,
            hotel.Photos,
            roomsAvailable[hotel.Coordinates].RoomsAvailable,
            roomsInfo[hotel.Coordinates].MaxPrice,
            roomsInfo[hotel.Coordinates].MinPrice));

        return order switch
        {
            HotelOrdering.Rating => hotelModels.OrderByDescending(h => h.Rating),
            HotelOrdering.RoomsAvailable => hotelModels.OrderByDescending(h => h.RoomsAvailable),
            _ => throw new ArgumentOutOfRangeException(nameof(order))
        };
    }

}