using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Constant;
public class Constant
{        // Constant for the role of admin user
    public const string Admin = "Admin";

    // Constant for the role of Employee user
    public const string User = "User";
}
public class ApiRoute {
    public const string Register = "Register";
    public const string Login = "Login";
    public const string Refresh = "Refresh";
    public const string GetAllUser = "GetAllUser";
}

