
namespace Fedex.Domain.DTO;
public class ExpressFreightDetailDTO
{
    public string? BookingConfirmationNumber { get; set; }
    public int ShippersLoadAndCount { get; set; }
}

public class EmergencyContactNumberDTO
{
    public string? AreaCode { get; set; }
    public string? Extension { get; set; }
    public string? CountryCode { get; set; }
    public string? PersonalIdentificationNumber { get; set; }
    public string? LocalNumber { get; set; }
}
