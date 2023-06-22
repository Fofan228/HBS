using Dumpify;

using HBS.Core.Entities;
using HBS.Core.Models;
using HBS.Core.Services.HotelManagerService;
using HBS.Server.Controllers.Common;

using Microsoft.AspNetCore.Mvc;

namespace HBS.Server.Controllers;

[Route("[controller]")]
public class HotelController : ApiController
{
    private readonly IHotelManager _hotelManager;

    public HotelController(IHotelManager hotelManager)
    {
        _hotelManager = hotelManager;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<HotelModel>>> ListHotels(
        [FromQuery] HotelOrdering order, 
        [FromQuery] string city,
        CancellationToken token)
    {
        var hotels = await _hotelManager.ListHotelsAsync(order, city, token);
        hotels.Dump();
        return Ok(hotels);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<HotelModel>> GetById(long id, CancellationToken token)
    {
        var hotel = await _hotelManager.GetByIdAsync(id, token);
        return hotel is null ? NotFound() : Ok(hotel);
    }
}