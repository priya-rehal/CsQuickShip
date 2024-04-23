using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class BrokersDTO
{
    public BrokerDTO? Broker { get; set; }
    public string? Type { get; set; }
    public string? BrokerCommitTimestamp { get; set; }
    public string? BrokerCommitDayOfWeek { get; set; }
    public string? BrokerLocationId { get; set; }
    public BrokerAddressDTO? BrokerAddress { get; set; }
    public int BrokerToDestinationDays { get; set; }
}
public class BrokerDTO
{
    public AccountNumberDTO? AccountNumber { get; set; }
    public object? Address { get; set; }
    public object? Contact { get; set; }
}

public class BrokerAddressDTO
{
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; }
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
    public bool? Residential { get; set; }
    public string? Classification { get; set; }
    public string? GeographicCoordinates { get; set; }
    public string? UrbanizationCode { get; set; }
    public string? CountryName { get; set; }
}

public class BatteryDetailDTO
{
    public string? Material { get; set; }
    public string? RegulatorySubType { get; set; }
    public string? Packing { get; set; }
}
