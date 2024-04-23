using Label.Application.DTOs.LabelDTOs;
using Newtonsoft.Json;

namespace Label.Application.DTOs.CsQuickShipDTOs;
public class CsQuickShipResponse
{
    public CsQuickShipAddressResponse? AddressFrom { get; set; }
    public CsQuickShipAddressResponse? AddressTo { get; set; }
    public List<CsQuickShipPackagesResponse>? Packages { get; set; }
}
public class CsQuickShipPackagesResponse
{
    public string? TrackingNumber { get; set; }
    public string? EncodedLabel { get; set; }
}
public class CsQuickShipAddressResponse
{
    /// <summary>
    /// Combination of number, street name, etc. At least one line is required for a valid physical address. Empty lines should not be included. Max Length is 35
    /// </summary>
    [JsonProperty("streetLines")]
    public List<string>? StreetLines { get; set; }
    /// <summary>
    /// The name of city, town of the recipient.Max length is 35
    /// </summary>
    [JsonProperty("city")]
    public string? City { get; set; }
    /// <summary>
    /// The US States,Canada and Puerto Rico Province codes of the recipient. The Format and presence of this field may vary depending on the country.State code is required for US, CA, PR and not required for other countries. Conditional. Max length is 2.
    /// </summary>
    [JsonProperty("stateOrProvinceCode")]
    public string? StateOrProvinceCode { get; set; }
    /// <summary>
    /// This is the postal code.
    /// </summary>
    [JsonProperty("postalCode")]
    public string? PostalCode { get; set; }
    /// <summary>
    /// This is the two-letter country code.
    /// </summary>
    [JsonProperty("countryCode")]
    public string? CountryCode { get; set; }
    /// <summary>
    /// Indicate whether this address is residential (as opposed to commercial).
    /// </summary>
    [JsonProperty("residential")]
    public bool? Residential { get; set; }
}