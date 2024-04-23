using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackShip.Application.DTOs;
using TrackShip.Application.Queries;


namespace TrackShip.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TrackShipmentController : ControllerBase
{
    private readonly ISender _sender;
    public TrackShipmentController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("trackShipment")]
    public async Task<ActionResult<TrackShipmentResponseDto>>TrackShipments([FromBody]TrackShipmentRequestDto requestDto)
    {
         return Ok( await _sender.Send(new TrackShipmentQuery(requestDto)));
        
    } 

}
