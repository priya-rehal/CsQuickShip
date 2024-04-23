using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackShip.Application.DTOs;
public class CsShipResponseDTO
{
    public string? TransactionId { get; set; }
    public ResponseAddressDto? Address { get; set; }
    public List<CsResponsePackages>?Packages { get; set; }

}
public class ResponseAddressDto
{
    public CsAddressDto? FromAddress { get; set; }
    public CsAddressDto? ToAddress { get; set; }
}
public class CsAddressDto
{
    public string ? Address1 {  get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? StateCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
    public string? PersonName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? Email {  get; set; }
    /* public CSResponseAddress? Address { get; set; }
     public CsResponseContact? Contact { get; set; }*/
}
/*public class CSResponseAddress
{
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; }
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
}*/
public class CsResponseContact
{
   /* public string? PersonName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }*/
}
public class CsResponsePackages
{
    public int PackageId { get; set; }
    public CsResponseDiamensions? Diamensions { get; set; }
    public List<Label>? Labels { get; set; }
    public ResponseWeight? TotalBillingWeight { get; set; }
}
public class CsResponseDiamensions
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Units { get; set; }
}
public class ResponseWeight {
    public string? Units { get; set; }
    public double? Value { get; set; }
}
public class Label
{
    public string? DocType { get; set; }
    public string? Url { get; set; }
    public string? EncodedLabel { get; set; }
}