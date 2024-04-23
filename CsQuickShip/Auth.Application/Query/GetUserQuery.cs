﻿using Auth.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Query;
public class GetUserQuery:IRequest<List<UserDto>>
{
}
