using Label.Application.DTOs.LabelDTOs;
using Newtonsoft.Json;

namespace Label.Application.DTOs.CsQuickShipDTOs;
public class CsQuickShipRequest
{
    /// <summary>
    /// The descriptive data of the requested shipment.
    /// </summary>

    [JsonProperty("shipment")]
    public CsShipmentRequest? Shipment { get; set; }

    /// <summary>
    /// This is to specify whether the encoded bytecode or the Label URL to be returned in the response.
    /// </summary>

    [JsonProperty("labelResponseOptions")]
    public string? LabelResponseOptions { get; set; }

    /// <summary>
    /// The account number associated with the shipment.
    /// </summary>

    [JsonProperty("accountNumber")]
    public CsAccountNumberRequest? AccountNumber { get; set; }
}
public class CsShipmentRequest
{
    /// <summary>
    /// Indicate the Shipper contact details for this shipment.
    /// </summary>

    [JsonProperty("fromAddress")]
    public CsQuickShipAddressRequest? FromAddress { get; set; }
    /// <summary>
    /// Indicate the descriptive data for the recipient location to which the shipment is to be received.
    /// </summary>
    [JsonProperty("toAddress")]
    public CsQuickShipAddressRequest? ToAddress { get; set; }

    /// <summary>
    /// Indicate the pickup type method by which the shipment to be tendered to FedEx.
    /// </summary>
    [JsonProperty("pickupType")]
    public string? PickupType { get; set; }
    /// <summary>
    /// Indicate the FedEx service type used for this shipment.
    /// </summary>

    [JsonProperty("serviceType")]
    public string? ServiceLevelType { get; set; }
    /// <summary>
    /// Specify the packaging used.
    /// </summary>

    [JsonProperty("packagingType")]
    public string? PackagingType { get; set; }
    /// <summary>
    /// Specifies the payment details specifying the method and means of payment to FedEx for providing shipping services.
    /// </summary>

    [JsonProperty("shippingChargesPayment")]
    public CsShippingChargesPaymentRequest? ShippingChargesPayment { get; set; }

    /// <summary>
    /// These are label specification details includes the image type, printer format, and label stock for label. Can also specify specific details such as doc-tab content, regulatory labels, and masking data on the label.
    /// </summary>
    [JsonProperty("labelSpecification")]
    public CsLabelSpecificationRequest? LabelSpecification { get; set; }

    /// <summary>
    /// These are one or more package-attribute descriptions, each of which describes an individual package, a group of identical packages, or (for the total-piece-total-weight case) common characteristics of all packages in the shipment.
    /// </summary>
    [JsonProperty("packages")]
    public List<CsQuickShipPackagesRequest>? Packages { get; set; }
}
public class CsQuickShipAddressRequest
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public CsAddressRequest? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public CsContactRequest? Contact { get; set; }
}
public class CsQuickShipPackagesRequest
{
    /// <summary>
    /// These are the package weight details.
    /// </summary>
    [JsonProperty("weight")]
    public CsWeightRequest? Weight { get; set; }
    /// <summary>
    /// These are special services that are available at the package level for some or all service types.
    /// </summary>
    [JsonProperty("packageSpecialServices")]
    public CsPackageSpecialServicesRequest? PackageSpecialServices { get; set; }
}
public class CsShippingChargesPaymentRequest

{
    /// <summary>
    /// Specifies the payment Type.
    /// </summary>
    [JsonProperty("paymentType")]
    public string? PaymentType { get; set; }
}
public class CsLabelSpecificationRequest

{
    /// <summary>
    /// Indicate the label stock type used.
    /// </summary>
    [JsonProperty("labelStockType")]
    public string? LabelStockType { get; set; }
    /// <summary>
    /// Specify the image format used for a shipping document.
    /// </summary>
    [JsonProperty("imageType")]
    public string? ImageType { get; set; }
}
public class CsPackageSpecialServicesRequest

{
    /// <summary>
    /// Indicate the types of special services requested for the shipment.
    /// </summary>
    [JsonProperty("specialServiceTypes")]
    public List<string>? SpecialServiceTypes { get; set; }
    /// <summary>
    /// Indicate the Signature Type.
    /// </summary>
    [JsonProperty("signatureOptionType")]
    public string? SignatureOptionType { get; set; }
    /// <summary>
    /// Specifies the Priority Alert Detail.
    /// </summary>
    [JsonProperty("priorityAlertDetail")]
    public PriorityAlertDetail? PriorityAlertDetail { get; set; }
    /// <summary>
    /// This element specifies Signature option details.
    /// </summary>
    [JsonProperty("signatureOptionDetail")]
    public SignatureOptionDetail? SignatureOptionDetail { get; set; }
    /// <summary>
    /// These are detcontentails for the package containing alcohol. This is required for alcohol special service. The alcoholRecipientType is required.
    /// </summary>
    [JsonProperty("alcoholDetail")]
    public AlcoholDetail? AlcoholDetail { get; set; }
    /// <summary>
    /// Provide dangerous goods shipment details.
    /// </summary>
    [JsonProperty("dangerousGoodsDetail")]
    public DangerousGoodsDetail? DangerousGoodsDetail { get; set; }
    /// <summary>
    /// These are COD package details. For use with FedEx Ground services only; COD must be present in shipments special services.
    /// </summary>
    [JsonProperty("packageCODDetail")]
    public PackageCODDetail? PackageCODDetail { get; set; }
    /// <summary>
    /// Provide the pieceCount or VerificationBoxCount for batteries or cells that are contained within this specific package.
    /// </summary>
    [JsonProperty("pieceCountVerificationBoxCount")]
    public int? PieceCountVerificationBoxCount { get; set; }
    /// <summary>
    /// Provide details about the batteries or cells that are contained within this specific package.
    /// </summary>
    [JsonProperty("batteryDetails")]
    public List<BatteryDetail>? BatteryDetails { get; set; }
    /// <summary>
    /// These are the package weight details.
    /// </summary>
    [JsonProperty("dryIceWeight")]
    public DryIceWeight? DryIceWeight { get; set; }
}
public class CsAddressRequest
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
public class CsContactRequest
{
    /// <summary>
    /// Specify contact name. Specify contact name.
    /// </summary>
    [JsonProperty("personName")]
    public string? PersonName { get; set; }
    /// <summary>
    /// Specify contact email address. Maximum length is 80.
    /// </summary>
    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }
    /// <summary>
    /// Specify contact phone extension. Maximum length is 6.
    /// </summary>

    [JsonProperty("phoneExtension")]
    public string? PhoneExtension { get; set; }
    /// <summary>
    /// The shipper's phone number.
    /// Minimum length is 10 and supports maximum of 15 for certain countries using longer phone numbers.
    /// </summary>

    [JsonProperty("phoneNumber")]
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Specify contact company name. Maximum length is 35.
    /// </summary>

    [JsonProperty("companyName")]
    public string? CompanyName { get; set; }

}
public class CsWeightRequest
{
    /// <summary>
    /// Indicate the weight unit type. The package and commodity weight unit should be the same else the request will result in an error.
    /// </summary>
    [JsonProperty("units")]
    public string? Units { get; set; }
    /// <summary>
    /// Weight Value.
    /// </summary>
    [JsonProperty("value")]
    public double? Value { get; set; }
}
public class CsAccountNumberRequest
{
    /// <summary>
    /// The account number value.Value is required if the paymentType is RECIPIENT, THIRD_PARTY or COLLECT.
    /// </summary>
    [JsonProperty("value")]
    public string? Value { get; set; }
}
