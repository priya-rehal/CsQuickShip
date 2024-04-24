using Fedex.Application.CQRS.Commands;
using Fedex.Application.Helper;
using Fedex.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Mime;
using System.Windows.Input;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class RatesQuotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RatesQuotesController(IMediator mediator) => _mediator = mediator;

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("RatesQuote")]
    public async Task<IActionResult> GetRatesQuotes(RateQuoteRequestDTO? rateRequest)
    {
      
        if (ModelState.IsValid)
        {
            dynamic command = rateRequest?.CarrierType switch
            {
                CarrierType.FEDEX => new RatesCommand(DTOParseHelper.ParseFedexRate(rateRequest)),
                CarrierType.DHL => new DHLRatesCommand(DTOParseHelper.ParseDHLRate(rateRequest)),
                CarrierType.AMAZONE => throw new NotImplementedException(),
                CarrierType.SHIPPOST => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
             dynamic responseObject = await _mediator.Send(command);
            return responseObject != null ? Ok(responseObject) : BadRequest(responseObject);
        }
        return BadRequest();
    }

   



}
