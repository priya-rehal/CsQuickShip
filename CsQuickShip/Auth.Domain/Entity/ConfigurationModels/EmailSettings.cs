public class EmailSettings
{
    public const string Section = "EmailSettings";
    public string PrimaryDomain { get; init; } = null!;
    public int PrimaryPort { get; init; } = 0;
    public string Username { get; init; }=null!;
    public string Password { get; init; } = null!;
    public string DefaultFromEmail { get; init; } = null!;
}
