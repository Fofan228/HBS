using HBS.Core.Common.Repositories.Interfaces;
using HBS.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

//TODO CREATE HEALTHCHECK (Попросили проверить, живой ли сервис)
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelManager _hotelManager;
    
    public HotelController(IHotelManager hotelManager)
    {
        _hotelManager = hotelManager;
    }

    [HttpGet("/live")]
    public async Task GetLiveStatus()
    {
        await Response.WriteAsync("I am a Live");
    }
    
    [HttpGet("/nearby")]
    public ActionResult<IAsyncEnumerable<HotelModel>> GetNearbyHotels([FromQuery] Coordinate coordinate)
    {
        return Ok();
    }
}