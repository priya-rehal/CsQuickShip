using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackShip.Application.Command;
using TrackShip.Application.DTOs;

namespace TrackShip.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShipController : ControllerBase
{
    private readonly ISender _sender;
    public ShipController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost("ship")]
    public async Task<ActionResult<CsShipResponseDTO>> ship([FromBody]ShipRequestDTO shipRequestDTO)
    {
        return Ok(await _sender.Send(new ShipCommand(shipRequestDTO)));
    }
}
