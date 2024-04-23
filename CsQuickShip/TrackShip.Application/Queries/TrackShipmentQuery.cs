using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackShip.Application.DTOs;

namespace TrackShip.Application.Queries;
public class TrackShipmentQuery : IRequest<TrackShipmentResponseDto>
{
    public TrackShipmentRequestDto _trackRequest { get; set; }
    public TrackShipmentQuery(TrackShipmentRequestDto trackRequest)
    {
        _trackRequest = trackRequest;
    }
}

