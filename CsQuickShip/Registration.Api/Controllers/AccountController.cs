using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Registration.Application.Commands;
using Registration.Application.DTOs;
using Registration.Application.Queries;


namespace Registration.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;
    public AccountController(ISender sender)=>_sender=sender;

    [HttpPost("GetAccessToken")]
    public async Task<ActionResult< string>> GetAccessToken(string clientId, string clientSecret)
    {
       return Ok( await _sender.Send(new GetAccessTokenQuery(clientId, clientSecret)));
    }
    [HttpPost("CredentialRegistration")]
    public async Task<ActionResult< RegisterCredentialResponse>>CreateCustomerCredentials(RegisterCredentialsRequestDto credentialsDto)
    {

        return Ok( await _sender.Send(new GenricRegisterCommand(credentialsDto)));
    }
}

