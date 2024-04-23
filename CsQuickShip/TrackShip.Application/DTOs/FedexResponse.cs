
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TrackShip.Application.Handler
{
    public class FedexResponse
    {
        /// <summary>
        /// The transaction ID is a special set of numbers that defines each transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string? TransactionId { get; set; }
        /// <summary>
        /// This element has a unique identifier added in your request, helps you match the request to the reply.
        /// </summary>
        [JsonProperty("customerTransactionId")]
        public string? CustomerTransactionId { get; set; }
        /// <summary>
        /// This is the response received when a shipment is requested.
        /// </summary>
        [JsonProperty("output")]
        public Output? Output { get; set; }
    }

    public class Output
    {
        /// <summary>
        /// Indicate the FedEx serviceType used for this shipment. The results will be filtered by the serviceType value indicated.
        /// </summary>
        [JsonProperty("transactionShipments")]
        public List<TransactionShipments>? TransactionShipments { get; set; }
        /// <summary>
        /// The alerts received when processing a shipment request.
        /// </summary>
        [JsonProperty("alerts")]
        public List<Alert>? Alerts { get; set; }
        /// <summary>
        /// Unique identifier for a Job. Example: abc123456
        /// </summary>
        [JsonProperty("jobId")]
        public string? JobId { get; set; }
    }

    public class TransactionShipments
    {
        /// <summary>
        /// Indicate the FedEx serviceType used for this shipment. The results will be filtered by the serviceType value indicated.
        /// </summary>
        [JsonProperty("serviceType")]
        public string? ServiceType { get; set; }
        /// <summary>
        /// This is the shipment date. Default value is current date in case the date is not provided or a past date is provided.
        /// </summary>
        [JsonProperty("shipDatestamp")]
        public string? ShipDatestamp { get; set; }
        /// <summary>
        /// This is the service name associated with the shipment.
        /// </summary>
        [JsonProperty("serviceName")]
        public string? ServiceName { get; set; }
        /// <summary>
        /// Indicates the Service Category.
        /// </summary>
        [JsonProperty("serviceCategory")]
        public string? ServiceCategory { get; set; }
        /// <summary>
        /// These are shipping document details.
        /// </summary>
        [JsonProperty("shipmentDocuments")]
        public List<ShipmentDocuments>? ShipmentDocuments { get; set; }
        /// <summary>
        /// Specifies the information about the pieces, received in the response.
        /// </summary>
        [JsonProperty("pieceResponses")]
        public List<PieceResponses>? PieceResponses { get; set; }
        /// <summary>
        /// These are alert details received in the response.
        /// </summary>
        [JsonProperty("alerts")]
        public List<Alert>? Alerts { get; set; }
        /// <summary>
        /// These are shipment advisory details.
        /// </summary>
        [JsonProperty("shipmentAdvisoryDetails")]
        public ShipmentAdvisoryDetails? ShipmentAdvisoryDetails { get; set; }
        /// <summary>
        /// Returns the result of processing the desired package as a single-package shipment.
        /// </summary>
        [JsonProperty("completedShipmentDetail")]
        public CompletedShipmentDetail? CompletedShipmentDetail { get; set; }
        /// <summary>
        /// This is a master tracking number for the shipment (must be unique for stand-alone open shipments, or unique within consolidation if consolidation key is provided).
        /// </summary>
        [JsonProperty("masterTrackingNumber")]
        public string? MasterTrackingNumber { get; set; }
    }

    public class Alert
    {
        [JsonProperty("code")]
        public string? Code { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("alertType")]
        public string? AlertType { get; set; }
        [JsonProperty("parameterList")]
        public List<string?>? ParameterList { get; set; }
    }

    public class ShipmentDocuments
    {
        [JsonProperty("contentKey")]
        public string? ContentKey { get; set; }
        [JsonProperty("copiesToPrint")]
        public string? CopiesToPrint { get; set; }
        [JsonProperty("contentType")]
        public string? ContentType { get; set; }
        [JsonProperty("trackingNumber")]
        public string? TrackingNumber { get; set; }
        [JsonProperty("docType")]
        public string? DocType { get; set; }
        [JsonProperty("alerts")]
        public List<Alert>? Alerts { get; set; }
        [JsonProperty("encodedLabel")]
        public string? EncodedLabel { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
    }

    public class PieceResponses
    {
        [JsonProperty("netChargeAmount")]
        public string? NetChargeAmount { get; set; }
        [JsonProperty("transactionDetails")]
        public List<TransactionDetail>? TransactionDetails { get; set; }
        [JsonProperty("packageDocuments")]
        public List<ShipmentDocuments>? PackageDocuments { get; set; }
        [JsonProperty("acceptanceTrackingNumber")]
        public string? AcceptanceTrackingNumber { get; set; }
        [JsonProperty("serviceCategory")]
        public string? ServiceCategory { get; set; }
        [JsonProperty("listCustomerTotalCharge")]
        public string? ListCustomerTotalCharge { get; set; }
        [JsonProperty("deliveryTimestamp")]
        public string? DeliveryTimestamp { get; set; }
        [JsonProperty("trackingIdType")]
        public string? TrackingIdType { get; set; }
        [JsonProperty("additionalChargesDiscount")]
        public double AdditionalChargesDiscount { get; set; }
        [JsonProperty("netListRateAmount")]
        public double NetListRateAmount { get; set; }
        [JsonProperty("baseRateAmount")]
        public double BaseRateAmount { get; set; }
        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }
        [JsonProperty("netDiscountAmount")]
        public double NetDiscountAmount { get; set; }
        [JsonProperty("codcollectionAmount")]
        public string? CodcollectionAmount { get; set; }
        [JsonProperty("masterTrackingNumber")]
        public string? MasterTrackingNumber { get; set; }
        [JsonProperty("acceptanceType")]
        public string? AcceptanceType { get; set; }
        [JsonProperty("trackingNumber")]
        public string? TrackingNumber { get; set; }
        [JsonProperty("successful")]
        public bool Successful { get; set; }
        [JsonProperty("customerReferences")]
        public List<CustomerReference>? CustomerReferences { get; set; }
    }

    public class TransactionDetail
    {
        [JsonProperty("transactionDetails")]
        public string TransactionDetails { get; set; }
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }

    public class CompletedShipmentDetail
    {
        [JsonProperty("completedPackageDetails")]
        public List<CompletedPackageDetails>? CompletedPackageDetails { get; set; }
        [JsonProperty("operationalDetail")]
        public OperationalDetail? OperationalDetail { get; set; }
        [JsonProperty("carrierCode")]
        public string? CarrierCode { get; set; }
        [JsonProperty("completedHoldAtLocationDetail")]
        public CompletedHoldAtLocationDetail? CompletedHoldAtLocationDetail { get; set; }
        [JsonProperty("completedEtdDetail")]
        public CompletedEtdDetail? CompletedEtdDetail { get; set; }
        [JsonProperty("packagingDescription")]
        public string? PackagingDescription { get; set; }
        [JsonProperty("masterTrackingId")]
        public MasterTrackingId? MasterTrackingId { get; set; }
        [JsonProperty("serviceDescription")]
        public ServiceDescription? ServiceDescription { get; set; }
        [JsonProperty("usDomestic")]
        public bool UsDomestic { get; set; }
        [JsonProperty("hazardousShipmentDetail")]
        public HazardousShipmentDetail? HazardousShipmentDetail { get; set; }
        [JsonProperty("shipmentRating")]
        public ShipmentRating? ShipmentRating { get; set; }
        [JsonProperty("documentRequirements")]
        public DocumentRequirements? DocumentRequirements { get; set; }
        [JsonProperty("exportComplianceStatement")]
        public string? ExportComplianceStatement { get; set; }
        [JsonProperty("accessDetail")]
        public AccessDetails? AccessDetail { get; set; }
    }

    public class ShipmentRating
    {
        [JsonProperty("actualRateType")]
        public string? ActualRateType { get; set; }
        [JsonProperty("shipmentRateDetails")]
        public List<ShipmentRateDetails>? ShipmentRateDetails { get; set; }
    }

    public class ShipmentRateDetails
    {
        [JsonProperty("rateZone")]
        public string? RateZone { get; set; }
        [JsonProperty("ratedWeightMethod")]
        public string? RatedWeightMethod { get; set; }
        [JsonProperty("totalDutiesTaxesAndFees")]
        public double TotalDutiesTaxesAndFees { get; set; }
        [JsonProperty("pricingCode")]
        public string? PricingCode { get; set; }
        [JsonProperty("totalFreightDiscounts")]
        public double TotalFreightDiscounts { get; set; }
        [JsonProperty("totalFees")]
        public double TotalFees { get; set; }
        [JsonProperty("totalDutiesAndTaxes")]
        public double TotalDutiesAndTaxes { get; set; }
        [JsonProperty("totalAncillaryFeesAndTaxes")]
        public double TotalAncillaryFeesAndTaxes { get; set; }
        [JsonProperty("taxes")]
        public List<Tax>? Taxes { get; set; }
        [JsonProperty("totalRebates")]
        public double TotalRebates { get; set; }
        [JsonProperty("fuelSurchargePercent")]
        public double FuelSurchargePercent { get; set; }
        [JsonProperty("currencyExchangeRate")]
        public CurrencyExchangeRate? CurrencyExchangeRate { get; set; }
        [JsonProperty("totalNetFreight")]
        public double TotalNetFreight { get; set; }
        [JsonProperty("totalNetFedExCharge")]
        public double TotalNetFedExCharge { get; set; }
        [JsonProperty("shipmentLegRateDetails")]
        public List<ShipmentLegRateDetails>? ShipmentLegRateDetails { get; set; }
        [JsonProperty("dimDivisor")]
        public int DimDivisor { get; set; }
        [JsonProperty("rateType")]
        public string? RateType { get; set; }
        [JsonProperty("surcharges")]
        public List<Surcharge>? Surcharges { get; set; }
        [JsonProperty("totalSurchanges")]
        public double TotalSurchanges { get; set; }
        [JsonProperty("totalBillingWeight")]
        public TotalBillingWeight? TotalBillingWeight { get; set; }
        [JsonProperty("freightDiscount")]
        public List<FreightDiscount>? FreightDiscount { get; set; }
        [JsonProperty("rateScale")]
        public string? RateScale { get; set; }
        [JsonProperty("totalNetCharge")]
        public double TotalNetCharge { get; set; }
        [JsonProperty("totalBaseCharge")]
        public double TotalBaseCharge { get; set; }
        [JsonProperty("totalNetChargeWithDutiesAndTaxes")]
        public double TotalNetChargeWithDutiesAndTaxes { get; set; }
        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }

    public class ShipmentLegRateDetails
    {
        [JsonProperty("rateZone")]
        public string? RateZone { get; set; }
        [JsonProperty("pricingZone")]
        public string? PricingZone { get; set; }
        [JsonProperty("taxes")]
        public List<Tax>? Taxes { get; set; }
        [JsonProperty("totalRebates")]
        public double TotalRebates { get; set; }
        [JsonProperty("fuelSurchargePercent")]
        public double FuelSurchargePercent { get; set; }
        [JsonProperty("currencyExchangeRate")]
        public CurrencyExchangeRate? CurrencyExchangeRate { get; set; }
        [JsonProperty("dimDivisor")]
        public int DimDivisor { get; set; }
        [JsonProperty("rateType")]
        public string? RateType { get; set; }
        [JsonProperty("legDestinationLocationId")]
        public string? LegDestinationLocationId { get; set; }
        [JsonProperty("dimDivisorType")]
        public string? DimDivisorType { get; set; }
        [JsonProperty("totalBaseCharge")]
        public double TotalBaseCharge { get; set; }
        [JsonProperty("ratedWeightMethod")]
        public string? RatedWeightMethod { get; set; }
        [JsonProperty("totalFreightDiscounts")]
        public double TotalFreightDiscounts { get; set; }
        [JsonProperty("totalTaxes")]
        public double TotalTaxes { get; set; }
        [JsonProperty("minimumChargeType")]
        public string? MinimumChargeType { get; set; }
        [JsonProperty("totalDutiesAndTaxes")]
        public double TotalDutiesAndTaxes { get; set; }
        [JsonProperty("totalNetFreight")]
        public double TotalNetFreight { get; set; }
        [JsonProperty("totalNetFedExCharge")]
        public double TotalNetFedExCharge { get; set; }
        [JsonProperty("surcharge")]
        public List<Surcharge>? Surcharge { get; set; }
        [JsonProperty("totalSurcharges")]
        public double TotalSurcharges { get; set; }
        [JsonProperty("totalBillingWeight")]
        public TotalBillingWeight? TotalBillingWeight { get; set; }
        [JsonProperty("freightDiscounts")]
        public List<FreightDiscount>? FreightDiscounts { get; set; }
        [JsonProperty("rateScale")]
        public string? RateScale { get; set; }
        [JsonProperty("totalNetCharge")]
        public double TotalNetCharge { get; set; }
        [JsonProperty("totalNetChargeWithDutiesAndTaxes")]
        public double TotalNetChargeWithDutiesAndTaxes { get; set; }
        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }

    public class TotalBillingWeight
    {
        [JsonProperty("units")]
        public string? Units { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class FreightDiscount { }

    public class Surcharge
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("surchargeType")]
        public string? SurchargeType { get; set; }
        [JsonProperty("level")]
        public string? Level { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Tax
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("label")]
        public string? Label { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class CurrencyExchangeRate
    {
        [JsonProperty("rate")]
        public double Rate { get; set; }
        [JsonProperty("fromCurrency")]
        public string? FromCurrency { get; set; }
        [JsonProperty("intoCurrency")]
        public string? IntoCurrency { get; set; }
    }
    public class DocumentRequirements
    {
        [JsonProperty("requiredDocuments")]
        public List<string?>? RequiredDocuments { get; set; }
        [JsonProperty("prohibitedDocuments")]
        public List<string?>? ProhibitedDocuments { get; set; }
        [JsonProperty("generationDetails")]
        public List<GenerationDetails>? GenerationDetails { get; set; }
    }

    public class GenerationDetails { }

    public class AccessDetails
    {
        [JsonProperty("accessorDetails")]
        public List<AccessorDetails>? AccessorDetails { get; set; }
    }

    public class AccessorDetails
    {
        [JsonProperty("password")]
        public string? Password { get; set; }
        [JsonProperty("role")]
        public string? Role { get; set; }
        [JsonProperty("emailLabelUrl")]
        public string? EmailLabelUrl { get; set; }
        [JsonProperty("userId")]
        public string? UserId { get; set; }
    }

    public class HazardousShipmentDetail
    {
        [JsonProperty("hazardousSummaryDetail")]
        public HazardousSummaryDetail? HazardousSummaryDetail { get; set; }
        [JsonProperty("adrLicense")]
        public AdrLicense? AdrLicense { get; set; }
        [JsonProperty("licenseOrPermitDetail")]
        public LicenseOrPermitDetail? LicenseOrPermitDetail { get; set; }
    }

    public class HazardousSummaryDetail
    {
        [JsonProperty("smallQuantityExceptionPackageCount")]
        public int SmallQuantityExceptionPackageCount { get; set; }
    }

    public class AdrLicense
    {
        [JsonProperty("licenseOrPermitDetail")]
        public LicenseOrPermitDetail? LicenseOrPermitDetail { get; set; }
    }

    public class LicenseOrPermitDetail
    {
        [JsonProperty("number")]
        public string? Number { get; set; }
        [JsonProperty("effectiveDate")]
        public string? EffectiveDate { get; set; }
        [JsonProperty("expirationDate")]
        public string? ExpirationDate { get; set; }
    }

    public class DryIceDetail
    {
        [JsonProperty("totalWeight")]
        public TotalWeight? TotalWeight { get; set; }
        [JsonProperty("packageCount")]
        public int PackageCount { get; set; }
        [JsonProperty("processingOptions")]
        public ProcessingOptions? ProcessingOptions { get; set; }
    }

    public class CompletedEtdDetail
    {
        [JsonProperty("folderId")]
        public string? FolderId { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("uploadDocumentReferenceDetail")]
        public UploadDocumentReferenceDetails? UploadDocumentReferenceDetail { get; set; }
    }

    public class UploadDocumentReferenceDetails
    {
        [JsonProperty("documentType")]
        public string? DocumentType { get; set; }
        [JsonProperty("documentReference")]
        public string? DocumentReference { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("documentId")]
        public string? DocumentId { get; set; }
    }

    public class CompletedHoldAtLocationDetail
    {
        [JsonProperty("holdingLocationType")]
        public string? HoldingLocationType { get; set; }
        [JsonProperty("holdingLocation")]
        public HoldingLocation? HoldingLocation { get; set; }
    }

    public class HoldingLocation
    {
        [JsonProperty("address")]
        public Address? Address { get; set; }
        [JsonProperty("contact")]
        public Contact? Contact { get; set; }
    }

    public class OperationalDetail
    {
        [JsonProperty("astraHandlingText")]
        public string? AstraHandlingText { get; set; }
        [JsonProperty("barcodes")]
        public Barcodes? Barcodes { get; set; }
        [JsonProperty("operationalInstructions")]
        public List<OperationalInstruction>? OperationalInstructions { get; set; }
    }
    public class CompletedPackageDetails
    {
        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }
        [JsonProperty("operationalDetail")]
        public OperationalDetail? OperationalDetail { get; set; }
        [JsonProperty("signatureOption")]
        public string? SignatureOption { get; set; }
        [JsonProperty("trackingId")]
        public TrackingId? TrackingId { get; set; }
        [JsonProperty("groupNumber")]
        public int GroupNumber { get; set; }
        [JsonProperty("oversizeClass")]
        public string? OversizeClass { get; set; }
        [JsonProperty("packageRating")]
        public PackageRating? PackageRating { get; set; }
        [JsonProperty("dryIceWeight")]
        public DryIceWeight? DryIceWeight { get; set; }
        [JsonProperty("hazardousPackageDetail")]
        public HazardousPackageDetail? HazardousPackageDetail { get; set; }
    }

    public class PackageRating
    {
        [JsonProperty("effectiveNetDiscount")]
        public double EffectiveNetDiscount { get; set; }
        [JsonProperty("actualRateType")]
        public string ActualRateType { get; set; }
        [JsonProperty("packageRateDetails")]
        public List<PackageRateDetails> PackageRateDetails { get; set; }
    }

    public class PackageRateDetails
    {
        [JsonProperty("ratedWeightMethod")]
        public string? RatedWeightMethod { get; set; }
        [JsonProperty("totalFreightDiscounts")]
        public double TotalFreightDiscounts { get; set; }
        [JsonProperty("totalTaxes")]
        public double TotalTaxes { get; set; }
        [JsonProperty("minimumChargeType")]
        public string? MinimumChargeType { get; set; }
        [JsonProperty("baseCharge")]
        public double BaseCharge { get; set; }
        [JsonProperty("totalRebates")]
        public double TotalRebates { get; set; }
        [JsonProperty("rateType")]
        public string? RateType { get; set; }
        [JsonProperty("billingWeight")]
        public TotalBillingWeight? BillingWeight { get; set; }
        [JsonProperty("netFreight")]
        public double NetFreight { get; set; }
        [JsonProperty("surcharges")]
        public List<Surcharge>? Surcharges { get; set; }
        [JsonProperty("totalSurcharges")]
        public double TotalSurcharges { get; set; }
        [JsonProperty("netFedExCharge")]
        public double NetFedExCharge { get; set; }
        [JsonProperty("netCharge")]
        public double NetCharge { get; set; }
        [JsonProperty("currency")]
        public string? Currency { get; set; }
    }
    public class Barcodes
    {
        [JsonProperty("binaryBarcodes")]
        public List<BinaryBarcode>? BinaryBarcodes { get; set; }
        [JsonProperty("stringBarcode")]
        public List<StringBarcode>? StringBarcode { get; set; }
    }

    public class BinaryBarcode
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class StringBarcode
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class OperationalInstruction
    {
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("content")]
        public string? Content { get; set; }
    }

    public class TrackingId
    {
        [JsonProperty("formId")]
        public string? FormId { get; set; }
        [JsonProperty("trackingIdType")]
        public string? TrackingIdType { get; set; }
        [JsonProperty("uspsApplicationId")]
        public int UspsApplicationId { get; set; }
        [JsonProperty("trackingNumber")]
        public int TrackingNumber { get; set; }
    }

    public class HazardousPackageDetail
    {
        [JsonProperty("regulation")]
        public string? Regulation { get; set; }
        [JsonProperty("accessibility")]
        public string? Accessibility { get; set; }
        [JsonProperty("labelType")]
        public string? LabelType { get; set; }
        [JsonProperty("containers")]
        public List<Container>? Containers { get; set; }
        [JsonProperty("cargoAircraftOnly")]
        public bool CargoAircraftOnly { get; set; }
        [JsonProperty("referenceId")]
        public string? ReferenceId { get; set; }
        [JsonProperty("radioactiveTransportIndex")]
        public double RadioactiveTransportIndex { get; set; }
    }

    public class Container
    {
        [JsonProperty("qvalue")]
        public double Qvalue { get; set; }
        [JsonProperty("hazardousCommodities")]
        public List<HazardousCommodities>? HazardousCommodities { get; set; }
    }
    public class HazardousCommodities
    {
        [JsonProperty("quantity")]
        public Quantity? Quantity { get; set; }
        [JsonProperty("options")]
        public Options Options { get; set; }
        [JsonProperty("description")]
        public Description? Description { get; set; }
        [JsonProperty("netExplosiveDetail")]
        public NetExplosiveDetail? NetExplosiveDetail { get; set; }
        [JsonProperty("massPoints")]
        public double MassPoints { get; set; }
    }

    public class Quantity
    {
        [JsonProperty("quantityType")]
        public string? QuantityType { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("units")]
        public string? Units { get; set; }
    }

    public class Options { }

    public class Description
    {
        [JsonProperty("sequenceNumber")]
        public int SequenceNumber { get; set; }
        [JsonProperty("packingInstructions")]
        public string? PackingInstructions { get; set; }
        [JsonProperty("subsidaryClasses")]
        public List<string?> SubsidaryClasses { get; set; }
        [JsonProperty("labelText")]
        public string? LabelText { get; set; }
        [JsonProperty("tunnelRestrictionCode")]
        public string? TunnelRestrictionCode { get; set; }
        [JsonProperty("specialProvisions")]
        public string? SpecialProvisions { get; set; }
        [JsonProperty("proproperShippingNameAndDescription")]
        public string? ProproperShippingNameAndDescription { get; set; }
        [JsonProperty("technicalName")]
        public string? TechnicalName { get; set; }
        [JsonProperty("symbols")]
        public string? Symbols { get; set; }
        [JsonProperty("authorization")]
        public string? Authorization { get; set; }
        [JsonProperty("attributes")]
        public List<string?> Attributes { get; set; }
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("packingGroup")]
        public string? PackingGroup { get; set; }
        [JsonProperty("properShippingName")]
        public string? ProperShippingName { get; set; }
        [JsonProperty("hazardClass")]
        public string? HazardClass { get; set; }
    }

    public class NetExplosiveDetail
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("units")]
        public string? Units { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
    }

    public class CompletedShipmentDetail_ShipmentDocuments { }

    public class ServiceDescription
    {
        [JsonProperty("serviceId")]
        public string? ServiceId { get; set; }
        [JsonProperty("serviceType")]
        public string? ServiceType { get; set; }
        [JsonProperty("code")]
        public string? Code { get; set; }
        [JsonProperty("names")]
        public List<Name>? Names { get; set; }
        [JsonProperty("operatingOrgCodes")]
        public List<string?>? OperatingOrgCodes { get; set; }
        [JsonProperty("serviceCategory")]
        public string? ServiceCategory { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("astraDescription")]
        public string? AstraDescription { get; set; }
    }

    public class Name
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("encoding")]
        public string? Encoding { get; set; }
        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class ShipmentAdvisoryDetails
    {
        [JsonProperty("regulatoryAdvisory")]
        public RegulatoryAdvisory? RegulatoryAdvisory { get; set; }
    }

    public class RegulatoryAdvisory
    {
        [JsonProperty("prohibitions")]
        public List<Prohibitions>? Prohibitions { get; set; }
    }

    public class Prohibitions
    {
        [JsonProperty("derivedHarmonizedCode")]
        public string? DerivedHarmonizedCode { get; set; }
        [JsonProperty("advisory")]
        public List<Advisory>? Advisory { get; set; }
        [JsonProperty("commodityIndex")]
        public string? CommodityIndex { get; set; }
        [JsonProperty("source")]
        public string? Source { get; set; }
        [JsonProperty("categories")]
        public string? Categories { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("waiver")]
        public List<Waiver>? Waiver { get; set; }
        [JsonProperty("status")]
        public string? Status { get; set; }
    }

    public class Waiver
    {
        [JsonProperty("advisories")]
        public List<Advisory>? Advisories { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("id")]
        public string? Id { get; set; }
    }

    public class Advisory
    {
        [JsonProperty("code")]
        public string? Code { get; set; }
        [JsonProperty("text")]
        public string? Text { get; set; }
        [JsonProperty("parameters")]
        public List<Parameters>? Parameters { get; set; }
        [JsonProperty("localizedText")]
        public string? LocalizedText { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("value")]
        public string? Value { get; set; }
    }

    public class CustomerReferences
    {
        [JsonProperty("customerReferenceType")]
        public string? CustomerReferenceType { get; set; }
        [JsonProperty("value")]
        public int? Value { get; set; }
    }
}

