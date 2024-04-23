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
    [Route(ApiRoute.GetAllUser)]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserDto> response = await _sender.Send(new GetUserQuery());
        return new ApiResponseActionResult<List<UserDto>>(response);

    }
}
