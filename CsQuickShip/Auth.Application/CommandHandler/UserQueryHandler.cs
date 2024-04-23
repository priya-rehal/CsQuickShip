using Auth.Application.DTO;
using Auth.Application.Query;
using Auth.Domain.Entity.Identity;
using Auth.Domain.Repositries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.CommandHandler;
public class UserQueryHandler : IRequestHandler<GetUserQuery, List<UserDto>>
{
    private readonly IUserRepository _userRepository;
    public UserQueryHandler(UserManager<ApplicationUser> userManager,IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {

        var users = await _userRepository.GetAllAsync();
        List<UserDto> result = new List<UserDto>();
        foreach (var user in users)
        {
            UserDto userDto = new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id
            };
            result.Add(userDto);
        }
        return result;
    }
}
