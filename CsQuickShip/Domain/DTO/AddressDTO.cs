using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class AddressDTO
{
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; } 
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; } 
    public string? CountryCode { get; set; }
    public bool Residential { get; set; } 
}
public class AlcoholDetailDTO
{
    public string? AlcoholRecipientType { get; set; }
    public string? ShipperAgreementType { get; set; }
}

public class AddTransportationChargesDetailDTO
{
    public string? RateType { get; set; }
    public string? RateLevelType { get; set; }
    public string? ChargeLevelType { get; set; }
    public string? ChargeType { get; set; }
}