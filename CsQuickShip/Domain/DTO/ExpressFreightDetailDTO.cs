using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
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
