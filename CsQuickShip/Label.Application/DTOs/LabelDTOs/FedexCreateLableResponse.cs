using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Label.Application.DTOs.LabelDTOs;
public class FedexCreateLabelResponse
{
    /// <summary>
    /// The transaction ID is a special set of numbers that defines each transaction.
    /// </summary>
    public string? TransactionId { get; set; }
    /// <summary>
    /// This element has a unique identifier added in your request, helps you match the request to the reply.
    /// </summary>
    public string? CustomerTransactionId { get; set; }
    /// <summary>
    /// This is the response received when a shipment is requested.
    /// </summary>
    public Output? Output { get; set; }
}
public class Output
{
    /// <summary>
    /// Indicate the FedEx serviceType used for this shipment. The results will be filtered by the serviceType value indicated.
    /// </summary>
    public List<TransactionShipments>? TransactionShipments { get; set; }
    /// <summary>
    /// The alerts received when processing a shipment request.
    /// </summary>
    public List<Alert>? Alerts { get; set; }
    /// <summary>
    /// Unique identifier for a Job. Example: abc123456
    /// </summary>
    public string? JobId { get; set; }
}
public class TransactionShipments
{
    /// <summary>
    /// Indicate the FedEx serviceType used for this shipment. The results will be filtered by the serviceType value indicated.
    /// </summary>
    public string? ServiceType { get; set; }
    /// <summary>
    /// This is the shipment date. Default value is current date in case the date is not provided or a past date is provided.
    /// </summary>
    public string? ShipDatestamp { get; set; }
    /// <summary>
    /// This is the service name associated with the shipment.
    /// </summary>
    public string? ServiceName { get; set; }
    /// <summary>
    /// Indicates the Service Category.
    /// </summary>
    public string? ServiceCategory { get; set; }
    /// <summary>
    /// These are shipping document details.
    /// </summary>
    public List<ShipmentDocuments>? ShipmentDocuments { get; set; }
    /// <summary>
    /// Specifies the information about the pieces, received in the response.
    /// </summary>
    public List<PieceResponses>? PieceResponses { get; set; }
    /// <summary>
    /// These are alert details received in the response.
    /// </summary>
    public List<Alert>? Alerts { get; set; }
    /// <summary>
    /// These are shipment advisory details.
    /// </summary>
    public ShipmentAdvisoryDetails? ShipmentAdvisoryDetails { get; set; }
    /// <summary>
    /// Returns the result of processing the desired package as a single-package shipment.
    /// </summary>
    public CompletedShipmentDetail? CompletedShipmentDetail { get; set; }
    /// <summary>
    /// This is a master tracking number for the shipment (must be unique for stand-alone open shipments, or unique within consolidation if consolidation key is provided).
    /// </summary>
    public string? MasterTrackingNumber { get; set; }
}
public class Alert
{
    public string? Code { get; set; }
    public string? Message { get; set; }
    public string? AlertType { get; set; }
    public List<string?>? ParameterList { get; set; }
}
public class ShipmentDocuments
{
    public string? ContentKey { get; set; }
    public string? CopiesToPrint { get; set; }
    public string? ContentType { get; set; }
    public string? TrackingNumber { get; set; }
    public string? DocType { get; set; }
    public List<Alert>? Alerts { get; set; }
    public string? EncodedLabel { get; set; }
    public string? Url { get; set; }
}
public class PieceResponses
{
    public string? NetChargeAmount { get; set; }
    public List<TransactionDetail>? TransactionDetails { get; set; }
    public List<ShipmentDocuments>? PackageDocuments { get; set; }
    public string? AcceptanceTrackingNumber { get; set; }
    public string? ServiceCategory { get; set; }
    public string? ListCustomerTotalCharge { get; set; }
    public string? DeliveryTimestamp { get; set; }
    public string? TrackingIdType { get; set; }
    public double AdditionalChargesDiscount { get; set; }
    public double NetListRateAmount { get; set; }
    public double BaseRateAmount { get; set; }
    public int PackageSequenceNumber { get; set; }
    public double NetDiscountAmount { get; set; }
    public double CodcollectionAmount { get; set; }
    public string? MasterTrackingNumber { get; set; }
    public string? AcceptanceType { get; set; }
    public string? TrackingNumber { get; set; }
    public bool Successful { get; set; }
    public List<CustomerReference>? CustomerReferences { get; set; }
}
public class TransactionDetail
{
    public string TransactionDetails { get; set; }
    public string TransactionId { get; set; }
}
public class CompletedShipmentDetail
{
    public List<CompletedPackageDetails>? CompletedPackageDetails { get; set; }
    public OperationalDetail? OperationalDetail { get; set; }
    public string? CarrierCode { get; set; }
    public CompletedHoldAtLocationDetail? CompletedHoldAtLocationDetail { get; set; }
    public CompletedEtdDetail? CompletedEtdDetail { get; set; }
    public string? packagingDescription { get; set; }
    public MasterTrackingId? MasterTrackingId { get; set; }
    public ServiceDescription? ServiceDescription { get; set; }
    public bool UsDomestic { get; set; }
    public HazardousShipmentDetail? HazardousShipmentDetail { get; set; }
    public ShipmentRating? ShipmentRating { get; set; }
    public DocumentRequirements? DocumentRequirements { get; set; }
    public string? ExportComplianceStatement { get; set; }
    public AccessDetails? AccessDetail { get; set; }
}
public class ShipmentRating
{
    public string? ActualRateType { get; set; }
    public List<ShipmentRateDetails>? ShipmentRateDetails { get; set; }
}
public class ShipmentRateDetails
{
    public string? RateZone { get; set; }
    public string? RatedWeightMethod { get; set; }
    public double TotalDutiesTaxesAndFees { get; set; }
    public string? PricingCode { get; set; }
    public double TotalFreightDiscounts { get; set; }
    public double TotalFees { get; set; }
    public double TotalDutiesAndTaxes { get; set; }
    public double TotalAncillaryFeesAndTaxes { get; set; }
    public List<Tax>? Taxes { get; set; }
    public double TotalRebates { get; set; }
    public double FuelSurchargePercent { get; set; }
    public CurrencyExchangeRate? CurrencyExchangeRate { get; set; }
    public double TotalNetFreight { get; set; }
    public double TotalNetFedExCharge { get; set; }
    public List<ShipmentRateDetails>? ShipmentLegRateDetails { get; set; }
    public int DimDivisor { get; set; }
    public string? RateType { get; set; }
    public List<Surcharge>? Surcharges { get; set; }
    public double TotalSurchanges { get; set; }
    public TotalBillingWeight? TotalBillingWeight { get; set; }
    public List<FreightDiscount>? FreightDiscount { get; set; }
    public string? RateScale { get; set; }
    public double TotalNetCharge { get; set; }
    public double TotalBaseCharge { get; set; }
    public double TotalNetChargeWithDutiesAndTaxes { get; set; }
    public string? Currency { get; set; }
}
public class ShipmentLegRateDetails
{
    public string? RateZone { get; set; }
    public string? PricingZone { get; set; }
    public List<Tax>? Taxes { get; set; }
    public double TotalRebates { get; set; }
    public double FuelSurchargePercent { get; set; }
    public CurrencyExchangeRate? CurrencyExchangeRate { get; set; }
    public int DimDivisor { get; set; }
    public string? RateType { get; set; }
    public string? LegDestinationLocationId { get; set; }
    public string? DimDivisorType { get; set; }
    public double TotalBaseCharge { get; set; }
    public string? RatedWeightMethod { get; set; }
    public double TotalFreightDiscounts { get; set; }
    public double TotalTaxes { get; set; }
    public string? MinimumChargeType { get; set; }
    public double TotalDutiesAndTaxes { get; set; }
    public double TotalNetFreight { get; set; }
    public double TotalNetFedExCharge { get; set; }
    public List<Surcharge>? Surcharge { get; set; }
    public double TotalSurcharges { get; set; }
    public TotalBillingWeight? TotalBillingWeight { get; set; }
    public List<FreightDiscount>? FreightDiscounts { get; set; }
    public string? RateScale { get; set; }
    public double TotalNetCharge { get; set; }
    public double TotalNetChargeWithDutiesAndTaxes { get; set; }
    public string? Currency { get; set; }
}
public class TotalBillingWeight
{
    public string? Units { get; set; }
    public double Value { get; set; }
}
public class FreightDiscount { }
public class Surcharge
{
    public double Amount { get; set; }
    public string? SurchargeType { get; set; }
    public string? Level { get; set; }
    public string? Description { get; set; }
}
public class Tax
{
    public double Amount { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
}
public class CurrencyExchangeRate
{
    public double Rate { get; set; }
    public string? FromCurrency { get; set; }
    public string? IntoCurrency { get; set; }
}
public class DocumentRequirements
{
    public List<string?>? RequiredDocuments { get; set; }
    public List<string?>? ProhibitedDocuments { get; set; }
    public List<GenerationDetails>? GenerationDetails { get; set; }
}
public class GenerationDetails { }
public class AccessDetails
{
    public List<AccessorDetails>? AccessorDetails { get; set; }
}
public class AccessorDetails
{
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? emailLabelUrl { get; set; }
    public string? UserId { get; set; }
}
public class HazardousShipmentDetail
{
    public HazardousSummaryDetail? HazardousSummaryDetail { get; set; }
    public AdrLicense? AdrLicense { get; set; }
    public LicenseOrPermitDetail? LicenseOrPermitDetail { get; set; }
}
public class HazardousSummaryDetail
{
    public int SmallQuantityExceptionPackageCount { get; set; }
}
public class AdrLicense
{
    public LicenseOrPermitDetail? LicenseOrPermitDetail { get; set; }
}
public class LicenseOrPermitDetail
{
    public string? Number { get; set; }
    public string? EffectiveDate { get; set; }
    public string? ExpirationDate { get; set; }
}
public class DryIceDetail
{
    public TotalWeight? TotalWeight { get; set; }
    public int PackageCount { get; set; }
    public ProcessingOptions? ProcessingOptions { get; set; }
}
public class CompletedEtdDetail
{
    public string? FolderId { get; set; }
    public string? Type { get; set; }
    public UploadDocumentReferenceDetails? UploadDocumentReferenceDetail { get; set; }
}
public class UploadDocumentReferenceDetails
{
    public string? DocumentType { get; set; }
    public string? DocumentReference { get; set; }
    public string? Description { get; set; }
    public string? DocumentId { get; set; }
}
public class CompletedHoldAtLocationDetail
{
    public string? HoldingLocationType { get; set; }
    public HoldingLocation? HoldingLocation { get; set; }
}
public class HoldingLocation
{
    public Address? Address { get; set; }
    public Contact? Contact { get; set; }
}
public class OperationalDetail
{
    public string? AstraHandlingText { get; set; }
    public Barcodes? Barcodes { get; set; }
    public List<OperationalInstruction>? OperationalInstructions { get; set; }
    //public string? UrsaPrefixCode { get; set; }
    //public string? UrsaSuffixCode { get; set; }
    //public string? OriginLocationId { get; set; }
    //public string? OriginLocationNumber { get; set; }
    //public string? OriginServiceArea { get; set; }
    //public string? DestinationLocationId { get; set; }
    //public string? DestinationLocationNumber { get; set; }
    //public string? DestinationServiceArea { get; set; }
    //public string? DestinationLocationStateOrProvinceCode { get; set; }
}
public class CompletedPackageDetails
{
    public int SequenceNumber { get; set; }
    public OperationalDetail? OperationalDetail { get; set; }
    public string? SignatureOption { get; set; }
    public TrackingId? TrackingId { get; set; }
    public int GroupNumber { get; set; }
    public string? OversizeClass { get; set; }
    public PackageRating? PackageRating { get; set; }
    public DryIceWeight? DryIceWeight { get; set; }
    public HazardousPackageDetail? HazardousPackageDetail { get; set; }
}
public class PackageRating
{
    public double EffectiveNetDiscount { get; set; }
    public string ActualRateType { get; set; }
    public List<PackageRateDetails> PackageRateDetails { get; set; }
}
public class PackageRateDetails
{
    public string? RatedWeightMethod { get; set; }
    public double TotalFreightDiscounts { get; set; }
    public double TotalTaxes { get; set; }
    public string? MinimumChargeType { get; set; }
    public double BaseCharge { get; set; }
    public double TotalRebates { get; set; }
    public string? RateType { get; set; }
    public TotalBillingWeight? BillingWeight { get; set; }
    public double NetFreight { get; set; }
    public List<Surcharge>? Surcharges { get; set; }
    public double TotalSurcharges { get; set; }
    public double NetFedExCharge { get; set; }
    public double NetCharge { get; set; }
    public string? Currency { get; set; }
}
public class OperationDetail
{
    public string? AstraHandlingText { get; set; }
    public Barcodes? Barcodes { get; set; }
    public List<OperationalInstruction>? OperationalInstruction { get; set; }

}
public class Barcodes
{
    public List<BinaryBarcode>? BinaryBarcodes { get; set; }
    public List<StringBarcode>? StringBarcode { get; set; }
}
public class BinaryBarcode
{
    public string? Type { get; set; }
    public string? Value { get; set; }
}
public class StringBarcode
{
    public string? Type { get; set; }
    public string? Value { get; set; }
}
public class OperationalInstruction
{
    public int Number { get; set; }
    public string? Content { get; set; }
}
public class TrackingId
{
    public string? FormId { get; set; }
    public string? TrackingIdType { get; set; }
    public int UspsApplicationId { get; set; }
    public int TrackingNumber { get; set; }
}
public class HazardousPackageDetail
{
    public string? Regulation { get; set; }
    public string? Accessibility { get; set; }
    public string? LabelType { get; set; }
    public List<Container>? Containers { get; set; }
    public bool CargoAircraftOnly { get; set; }
    public string? ReferenceId { get; set; }
    public double RadioactiveTransportIndex { get; set; }
}
public class Container
{
    public double Qvalue { get; set; }
    public List<HazardousCommodities>? HazardousCommodities { get; set; }
}
public class HazardousCommodities
{
    public Quantity? Quantity { get; set; }
    public Options Options { get; set; }
    public Description? Description { get; set; }
    public NetExplosiveDetail? NetExplosiveDetail { get; set; }
    public double MassPoints { get; set; }
}
public class Quantity
{
    public string? QuantityType { get; set; }
    public double Amount { get; set; }
    public string? Units { get; set; }
}
public class Options { }
public class Description
{
    public int SequenceNumber { get; set; }
    public string? PackingInstructions { get; set; }
    public List<string?> SubsidaryClasses { get; set; }
    public string? LabelText { get; set; }
    public string? TunnelRestrictionCode { get; set; }
    public string? SpecialProvisions { get; set; }
    public string? ProproperShippingNameAndDescription { get; set; }
    public string? TechnicalName { get; set; }
    public string? Symbols { get; set; }
    public string? Authorization { get; set; }
    public List<string?> Attributes { get; set; }
    public string? Id { get; set; }
    public string? PackingGroup { get; set; }
    public string? ProperShippingName { get; set; }
    public string? HazardClass { get; set; }
}
public class NetExplosiveDetail
{
    public double Amount { get; set; }
    public string? Units { get; set; }
    public string? Type { get; set; }
}
public class CompletedShipmentDetail_ShipmentDocuments { }
public class ServiceDescription
{
    public string? ServiceId { get; set; }
    public string? ServiceType { get; set; }
    public string? Code { get; set; }
    public List<Name>? Names { get; set; }
    public List<string?>? OperatingOrgCodes { get; set; }
    public string? ServiceCategory { get; set; }
    public string? Description { get; set; }
    public string? AstraDescription { get; set; }
}
public class Name
{
    public string? Type { get; set; }
    public string? Encoding { get; set; }
    public string? Value { get; set; }
}
public class ShipmentAdvisoryDetails
{
    public RegulatoryAdvisory? RegulatoryAdvisory { get; set; }
}
public class RegulatoryAdvisory
{
    public List<Prohibitions>? Prohibitions { get; set; }
}
public class Prohibitions
{
    public string? DerivedHarmonizedCode { get; set; }
    public List<Advisory>? Advisory { get; set; }
    public string? CommodityIndex { get; set; }
    public string? Source { get; set; }
    public string? Categories { get; set; }
    public string? Type { get; set; }
    public List<Waiver>? Waiver { get; set; }
    public string? Status { get; set; }
}
public class Waiver
{
    public List<Advisory>? Advisories { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
}
public class Advisory
{
    public string? Code { get; set; }
    public string? Text { get; set; }
    public List<Parameters>? Parameters
    { get; set; }
    public string? LocalizedText
    { get; set; }
}
public class Parameters
{
    public string? Id { get; set; }
    public string? Value { get; set; }
}
public class CustomerReferences
{
    public string? CustomerReferenceType { get; set; }
    public int? Value { get; set; }
}
