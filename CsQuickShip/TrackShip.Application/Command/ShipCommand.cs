using MediatR;
using TrackShip.Application.DTOs;
using TrackShip.Application.Handler;

namespace TrackShip.Application.Command;
public class ShipCommand:IRequest<CsShipResponseDTO>
{
    public ShipRequestDTO? _ShipRequest {  get; private set; }
    public ShipCommand(ShipRequestDTO? ShipRequest)
    {
        _ShipRequest = ShipRequest;
    }
}
