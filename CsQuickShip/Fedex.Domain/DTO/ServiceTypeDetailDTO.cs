
namespace Fedex.Domain.DTO;
public class ServiceTypeDetailDTO
{
    public string? CarrierCode { get; set; }
    public string? Description { get; set; }
    public string? ServiceName { get; set; }
    public string? ServiceCategory { get; set; }
}

public class ShipmentCODDetailDTO
{
    public AddTransportationChargesDetailDTO? AddTransportationChargesDetail { get; set; }
    public CodRecipientDTO? CodRecipient { get; set; }
    public string? RemitToName { get; set; }
    public string? CodCollectionType { get; set; }
    public FinancialInstitutionContactAndAddressDTO? FinancialInstitutionContactAndAddress { get; set; }
    public string? ReturnReferenceIndicatorType { get; set; }
}

public class ShipmentDryIceDetailDTO
{
    public TotalWeightDTO? TotalWeight { get; set; }
    public int PackageCount { get; set; }
}

public class ShipmentSpecialServicesDTO
{
    public ReturnShipmentDetailDTO? ReturnShipmentDetail { get; set; }
    public DeliveryOnInvoiceAcceptanceDetailDTO? DeliveryOnInvoiceAcceptanceDetail { get; set; }
    public InternationalTrafficInArmsRegulationsDetailDTO? InternationalTrafficInArmsRegulationsDetail { get; set; }
    public PendingShipmentDetailDTO? PendingShipmentDetail { get; set; }
    public HoldAtLocationDetailDTO? HoldAtLocationDetail { get; set; }
    public ShipmentCODDetailDTO? ShipmentCODDetail { get; set; }
    public ShipmentDryIceDetailDTO? ShipmentDryIceDetail { get; set; }
    public InternationalControlledExportDetailDTO? InternationalControlledExportDetail { get; set; }
    public HomeDeliveryPremiumDetailDTO? HomeDeliveryPremiumDetail { get; set; }
    public List<string>? SpecialServiceTypes { get; set; }
}
public class ShipperDTO
{
    public AddressDTO? Address { get; set; }
}

public class SmartPostInfoDetailDTO
{
    public string? AncillaryEndorsement { get; set; }
    public string? HubId { get; set; }
    public string? Indicia { get; set; }
    public string? SpecialServices { get; set; }
}

public class SmsDetailDTO
{
    public string? PhoneNumber { get; set; }
    public string? PhoneNumberCountryCode { get; set; }
}

public class TotalWeightDTO
{
    public string? Units { get; set; }
    public int Value { get; set; }
}

public class UnitPriceDTO
{
    public string?  Amount { get; set; }
    public string? Currency { get; set; }
}

public class VariableHandlingChargeDetailDTO
{
    public string? RateType { get; set; }
    public int PercentValue { get; set; }
    public string? RateLevelType { get; set; }
    public FixedValueDTO? FixedValue { get; set; }
    public string? RateElementBasis { get; set; }
}

public class WeightDTO
{
    public string? Units { get; set; }
    public double? Value { get; set; }
}
