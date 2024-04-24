using Auth.Application.Constant;
using Auth.Application.DTO;
using Auth.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ISender _sender;
    public UserController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserDto> response = await _sender.Send(new GetUserQuery());
        return new ApiResponseActionResult<List<UserDto>>(response);

    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserById(string Id)
    {
        List<UserDto> response = await _sender.Send(new GetUserQuery());
        return new ApiResponseActionResult<List<UserDto>>(response);

    }
}
