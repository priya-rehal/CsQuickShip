using Label.Application.DTOs.CsQuickShipDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Application.Commands;
public class CsQuickShipCreateLabelCommand : IRequest<CsQuickShipResponse>
{
    public CsQuickShipRequest CsQuickShipRequest { get; set; }
    public CsQuickShipCreateLabelCommand(CsQuickShipRequest csQuickShipRequest)
    {
        CsQuickShipRequest = csQuickShipRequest;
    }
}
