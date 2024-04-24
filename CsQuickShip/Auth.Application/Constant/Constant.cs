using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public const string RefreshToken = "RefreshToken";
    public const string GetAllUser = "GetAllUser";
    public const string ResetPassword = "ResetPassword";
    public const string EmailConfimation = "EmailConfimation";
    public const string ForgotPassword = "ForgotPassword";
}

public static class EmailBodyMessages
{
    public const string ConfirmEmailBody = "Please click on the following link to confirm your Email =>";
    public const string ForgotPasswordBody = "Please click on the following link to reset your password =>";
}
public static class EmailSubjects
{
    public const string ConfirmEmail = "Confirm Email Request";
    public const string ForgotPassword = "Password Reset Request";
}

public static class EmailCallBackFunction
{
    public static string GenerateCallbackUrl(string email, string token, UrlType type)
    {
        return type switch
        {
            UrlType.EmailConfirmation => $"{"Paste URL Here"}?email={email}&token={token}",
            UrlType.ForgetPassword => $"{"Paste URL Here"}?email={email}&token={token}",
            UrlType.ResetPassword => $"{"Paste URL Here"}?email={email}&token={token}",
            _ => throw new NotImplementedException()
        };
    }
}

public enum UrlType
{
    ResetPassword,
    ForgetPassword,
    EmailConfirmation
}
