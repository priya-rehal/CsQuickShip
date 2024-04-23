using Label.Application.Commands;
using Label.Application.DTOs.CsQuickShipDTOs;
using Label.Application.DTOs.LabelDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Label.Api.Controllers;

[ApiController]
public class LabelController : ControllerBase
{
    private IMediator _mediator;
    public LabelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("FedexLabelFromMyRequest")]
    public async Task<IActionResult> CreateLabel([FromBody] CsQuickShipRequest createLabelDto)
    {
        var res = await _mediator.Send(new CsQuickShipCreateLabelCommand(createLabelDto));
        if (res != null)
        {
            return Ok(res);
        }
        return BadRequest();
    }
}
