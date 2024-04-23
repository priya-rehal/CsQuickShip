using Auth.Application.DTO;
using Auth.Domain.Entity.Identity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsRegistrationLogin.Application.Mapper;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser,ApplicationUserDto>().ReverseMap();
        CreateMap<LoginResultDto, ApplicationUser>().ReverseMap();
    }
}
