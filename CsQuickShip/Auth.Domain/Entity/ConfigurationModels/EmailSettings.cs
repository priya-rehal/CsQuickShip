using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entity.ConfigurationModels;
public class EmailSettings
{
    public const string Section = "EmailSettings";
    public string PrimaryDomain { get; init; } = null!;
    public int PrimaryPort { get; init; }
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string DefaultFromEmail { get; init; } = null!;
}
