﻿
using Auth.Application.Command;
using Auth.Application.Constant;
using Auth.Application.DTO;
using Auth.Application.Query;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Auth.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;
    public AccountController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    [Route(ApiRoute.Register)]
    public async Task<IActionResult> Register(ApplicationUserDto user)
    {
        string userData = await _sender.Send(new RegistrationCommand(user));
        return new ApiResponseActionResult<string>(userData);
    }
    [HttpPost]
    [Route(ApiRoute.Login)]
    public async Task<IActionResult> Login(LoginDto user)
    {
        LoginResultDto resultDto = await _sender.Send(new LoginCommand(user));
        return new ApiResponseActionResult<LoginResultDto>(resultDto);
    }

    [HttpPost]
    [Route(ApiRoute.RefreshToken)]
    public async Task<IActionResult> Refresh(TokenDto tokenApiModel)
    {
       LoginResultDto response=await _sender.Send(new RefreshTokenCommand(tokenApiModel));
        return new ApiResponseActionResult<LoginResultDto>(response);

    }

    [HttpPost]
    [Route(ApiRoute.ForgotPassword)]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPassword)
    {
        bool response = await _sender.Send(new ForgotPasswordCommand(forgotPassword));
        return new ApiResponseActionResult<bool>(response);

    }

    [HttpPost]
    [Route(ApiRoute.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPassword)
    {
        bool response = await _sender.Send(new ResetPasswordCommand(resetPassword));
        return new ApiResponseActionResult<bool>(response);

    }

    [HttpPost]
    [Route(ApiRoute.EmailConfimation)]
    public async Task<IActionResult> EmailConfimation([FromBody] EmailConfirmDto emailConfirmDto)
    {
        bool response = await _sender.Send(new EmailConfirmationCommand(emailConfirmDto));
        return new ApiResponseActionResult<bool>(response);

    }
}