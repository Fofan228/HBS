using Dumpify;

using HBS.Core.Entities;
using HBS.Core.Models;
using HBS.Core.Repositories.Interfaces;
using HBS.Core.Web.Interfaces;
using HBS.Core.Web.Models;

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

        HotelRoomAvailableInfo? roomsAvailable;
        HotelRoomPricesInfo? roomsInfo;

        try
        {
            roomsInfo = (await _hotelRoomService.GetHotel(hotel.Coordinates.Longitude, hotel.Coordinates.Latitude))?.Hotel;
            _logger.LogInformation("{hotel}", roomsInfo.DumpText());
            roomsAvailable = (await _bookingService.GetAvailableRoomsAsync(new[] { hotel.Coordinates }))
                .FirstOrDefault();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting hotel {id}", id);
            return null;
        }

        if (roomsAvailable is null || roomsInfo is null)
        {
            _logger.LogError("Error while getting hotel {id}", id);
            return null;
        }

        var hotelModel = HotelModel.Create(hotel, roomsInfo, roomsAvailable);

        _logger.LogInformation("Hotel with {id} was found\n{hotel}", id, hotelModel.DumpText());

        return hotelModel;
    }

    public async Task<IEnumerable<HotelModel>> ListHotelsAsync(
        HotelOrdering order,
        string city,
        CancellationToken token)
    {
        var hotels = await _hotelRepository.ListHotels()
            .Where(h => h.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(token);
        var hotelCoordinates = hotels.ConvertAll(h => h.Coordinates);

        Dictionary<Coordinates, HotelRoomAvailableInfo> roomsAvailable;
        Dictionary<Coordinates, HotelRoomPricesInfo> roomsInfo;

        try
        {
            roomsInfo = (await _hotelRoomService.GetHotels()).Hotels
                            .ToDictionary(r => new Coordinates(r.Longitude, r.Latitude), r => r);
            _logger.LogInformation("{rooms}", roomsInfo.DumpText());
            roomsAvailable = (await _bookingService.GetAvailableRoomsAsync(hotelCoordinates))
                            .ToDictionary(r => r.Coordinates, r => r);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting rooms info");
            return Enumerable.Empty<HotelModel>();
        }

        var hotelModels = new List<HotelModel>();
        foreach (var hotel in hotels)
        {
            if (!roomsAvailable.TryGetValue(hotel.Coordinates, out var ra) ||
                !roomsInfo.TryGetValue(hotel.Coordinates, out var ri))
            {
                _logger.LogError("Error while getting rooms info for hotel: {id}", hotel.Id);
                continue;
            }

            hotelModels.Add(HotelModel.Create(hotel, ri, ra));
        }

        return order switch
        {
            HotelOrdering.Rating => hotelModels.OrderByDescending(h => h.Rating),
            HotelOrdering.RoomsAvailable => hotelModels.OrderByDescending(h => h.RoomsAvailable),
            _ => throw new ArgumentOutOfRangeException(nameof(order))
        };
    }

}