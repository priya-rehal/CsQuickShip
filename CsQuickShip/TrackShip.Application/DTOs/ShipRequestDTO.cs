using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrackShip.Application.DTOs;

public class ShipRequestDTO
{
    public CsRequestedShipment? RequestedShipment { get; set; }
    public string? LabelResponseOptions { get; set; }
    public CsAccountNumber? AccountNumber { get; set; }
}

public class CsRequestedShipment
{
    public CsRequestAddressDto? FromAddress { get; set; }
    public CsRequestAddressDto? ToAddress { get; set; }
    public string? PickupType { get; set; }
    public string? ServiceType { get; set; }
    public string? PackagingType { get; set; }
    public string? ShipDatestamp { get; set; }
    public CsShippingChargesPayment? ShippingChargesPayment { get; set; }
    public CsLabelSpecification? LabelSpecification { get; set; }
    public List<CsRequestedPackageLineItem>? RequestedPackageLineItems { get; set; }
}

public class CsRequestAddressDto
{
    public CSAddress? Address { get; set; }
    public CsContact? Contact { get; set; }
}

public class CSAddress
{
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; }
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
}

public class CsContact
{
    public string? PersonName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
}

public class CsShippingChargesPayment
{
    public string? PaymentType { get; set; }
}

public class CsLabelSpecification
{
    public string?ImageType { get; set; }
    public string? LabelStockType { get; set; }
}

public class CsRequestedPackageLineItem
{
    public CsWeight? Weight { get; set; }
}

public class CsWeight
{
    public string? Units { get; set; }
    public double Value { get; set; }
}

public class CsAccountNumber
{
    public string? Value { get; set; }
}
public class CsShipmentSpecialServices
{
    public List<string?>? SpecialServiceTypes { get; set; }
}