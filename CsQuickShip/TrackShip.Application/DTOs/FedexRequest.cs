using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrackShip.Application.Handler;


public class FedexRequest
{    /// <summary>
     /// It specifies the content of the merged pdf URL in the response. The merged pdf URL is generated only if the labelResponseOption is indicated as URL_ONLY.
     /// </summary>
    [JsonProperty("mergeLabelDocOption")]
    public string? MergeLabelDocOption { get; set; }
    /// <summary>
    /// The descriptive data of the requested shipment.
    /// </summary>

    [JsonProperty("requestedShipment")]
    public RequestedShipment? RequestedShipment { get; set; }
    /// <summary>
    /// This is to specify whether the encoded bytecode or the Label URL to be returned in the response.
    /// </summary>

    [JsonProperty("labelResponseOptions")]
    public string? LabelResponseOptions { get; set; }
    /// <summary>
    /// The account number associated with the shipment.
    /// </summary>

    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
    /// <summary>
    ///Indicate shipment action for the Shipment.
    /// </summary>

    [JsonProperty("shipAction")]
    public string? ShipAction { get; set; }
    /// <summary>
    ///Indicate the processing option for submitting a Single shot MPS shipment. The value indicates if the MPS to be processed synchronously or asynchronously.
    /// </summary>

    [JsonProperty("processingOptionType")]
    public string? ProcessingOptionType { get; set; }
    /// <summary>
    /// is flag is used to specify if the shipment is singleshot mps or one Label at a time, piece by piece shipment. Default is false. If true, one label at a time is processed.
    /// </summary>

    [JsonProperty("oneLabelAtATime")]
    public bool? OneLabelAtATime { get; set; }
}

public class AccountNumber
{
    /// <summary>
    /// The account number value.Value is required if the paymentType is RECIPIENT, THIRD_PARTY or COLLECT.
    /// </summary>
    [JsonProperty("value")]
    public string? Value { get; set; }
}

public class AdditionalLabel
{
    /// <summary>
    /// Specify the type of additional details to be added on the label.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
    /// <summary>
    ///Specifies the count of label to return.
    /// </summary>
    [JsonProperty("count")]
    public int? Count { get; set; }
}

public class AdditionalMeasure
{
    /// <summary>
    /// Specify commodity quantity.
    /// </summary>
    [JsonProperty("quantity")]
    public double? Quantity { get; set; }
    /// <summary>
    ///Unit of measure used to express the quantity of this commodity line item.
    /// </summary>
    [JsonProperty("units")]
    public string? Units { get; set; }
}

public class Address
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

public class AddTransportationChargesDetail
{
    /// <summary>
    /// Specify the Rate Type used.
    /// </summary>
    [JsonProperty("rateType")]
    public string? RateType { get; set; }
    /// <summary>
    /// Specify which level the rate to be applied.
    /// </summary>
    [JsonProperty("rateLevelType")]
    public string? RateLevelType { get; set; }
    /// <summary>
    /// Specify which level the charges to be applied.
    /// </summary>
    [JsonProperty("chargeLevelType")]
    public string? ChargeLevelType { get; set; }
    /// <summary>
    /// Specify Charge type.
    /// </summary>
    [JsonProperty("chargeType")]
    public string? ChargeType { get; set; }
}

public class AlcoholDetail
{
    /// <summary>
    /// Specify the Alcohol Recipient Type of the shipment.
    /// </summary>
    [JsonProperty("alcoholRecipientType")]
    public string? AlcoholRecipientType { get; set; }
    /// <summary>
    /// Specify the type of entity, the shipper for alcohol shipment is registered such as fulfillment house, retailer or a winery.
    /// </summary>
    [JsonProperty("shipperAgreementType")]
    public string? ShipperAgreementType { get; set; }
}

public class AttachedDocument
{
    /// <summary>
    /// Specify document type for the uploaded document. It should match with the type of uploaded document associated with documentId.
    /// </summary>
    [JsonProperty("documentType")]
    public string? DocumentType { get; set; }
    /// <summary>
    /// Specify the reference for the uploaded document.This is for the customer to reference their uploaded docs when they retrieve them. Could be anything, order number, po number, whatever the customer used to tie the document to something they would use.
    ///Note: Ensure to supply document references in case of Pre-Shipment document upload.
    /// </summary>
    [JsonProperty("documentReference")]
    public string? DocumentReference { get; set; }
    /// <summary>
    /// Specify additional information about the uploaded document for better understanding.
    /// Example: Certificate of Origin is uploaded for country of manufacturing verification.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
    /// <summary>
    /// This is the uploaded document ID value.
    /// </summary>
    [JsonProperty("documentId")]
    public string? DocumentId { get; set; }
}

public class Barcoded
{
    /// <summary>
    /// Indicates the type of barcode symbology used on FedEx documents and labels.
    /// </summary>
    [JsonProperty("symbology")]
    public string? Symbology { get; set; }
    /// <summary>
    /// Indicates the doc tab zone specification.
    /// </summary>
    [JsonProperty("specification")]
    public Specification? Specification { get; set; }
}

public class BatteryDetail
{
    /// <summary>
    /// Describe the packing arrangement of the battery or cell with respect to other items within the same package.
    /// </summary>
    [JsonProperty("batteryPackingType")]
    public string? BatteryPackingType { get; set; }
    /// <summary>
    /// This is a regulation specific classification for the battery or the cell.
    /// </summary>
    [JsonProperty("batteryRegulatoryType")]
    public string? BatteryRegulatoryType { get; set; }
    /// <summary>
    /// Indicate the material composition of the battery or cell.
    /// </summary>
    [JsonProperty("batteryMaterialType")]
    public string? BatteryMaterialType { get; set; }
}

public class BillingDetails
{
    /// <summary>
    /// Indicates a billing code.
    /// </summary>
    [JsonProperty("billingCode")]
    public string? BillingCode { get; set; }
    /// <summary>
    /// These are duties and taxes billing type.
    /// </summary>
    [JsonProperty("billingType")]
    public string? BillingType { get; set; }
    /// <summary>
    /// This is bill to alias identifier.
    /// </summary>
    [JsonProperty("aliasId")]
    public string? AliasId { get; set; }
    /// <summary>
    /// This is account nick name.
    /// </summary>
    [JsonProperty("accountNickname")]
    public string? AccountNickname { get; set; }
    /// <summary>
    ///This is bill to account number.
    /// </summary>
    [JsonProperty("accountNumber")]
    public string? AccountNumber { get; set; }
    /// <summary>
    /// This is the country code of the account number.
    /// </summary>
    [JsonProperty("accountNumberCountryCode")]
    public string? AccountNumberCountryCode { get; set; }
}

public class BlanketPeriod
{
    /// <summary>
    /// Indicates the start date.
    /// </summary>
    [JsonProperty("begins")]
    public string? Begins { get; set; }
    /// <summary>
    /// Indicates the end date.
    /// </summary>
    [JsonProperty("ends")]
    public string? Ends { get; set; }
}

public class Brokers
{
    /// <summary>
    /// These are broker details for the shipment with physical address, contact and account number information.
    /// </summary>
    [JsonProperty("broker")]
    public Broker? Broker { get; set; }
    /// <summary>
    /// Identifies the type of broker.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
}

public class Broker
{
    /// <summary>
    /// This is detailed information on physical location. May be used as an actual physical address (place to which one could go), or as a container of address parts which should be handled as a unit (such as a city-state-ZIP combination within the US).
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// This is FedEx Account number details.
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }

    [JsonProperty("deliveryInstructions")]
    public string? DeliveryInstructions { get; set; }
}

public class CertificateOfOrigin
{
    [JsonProperty("customerImageUsages")]
    public List<CustomerImageUsage>? CustomerImageUsages { get; set; }

    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
}

public class CodCollectionAmount
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    ///This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class CodRecipient
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// This is FedEx Account number details.
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
}

public class CommercialInvoice
{
    /// <summary>
    /// The originator name that will populate the Commercial Invoice (or Pro Forma).
    /// </summary>
    [JsonProperty("originatorName")]
    public string? OriginatorName { get; set; }
    /// <summary>
    /// The comments that will populate the Commercial Invoice (or Pro Forma). 
    /// </summary>
    [JsonProperty("comments")]
    public List<string>? Comments { get; set; }
    /// <summary>
    /// These are additional customer reference data for commercial invoice.
    /// </summary>
    [JsonProperty("customerReferences")]
    public List<CustomerReference>? CustomerReferences { get; set; }
    /// <summary>
    /// Indicate the taxes or miscellaneous charges(other than freight charges or insurance charges) that are associated with the shipment.
    /// </summary>
    [JsonProperty("taxesOrMiscellaneousCharge")]
    public TaxesOrMiscellaneousCharge? TaxesOrMiscellaneousCharge { get; set; }
    /// <summary>
    /// Indicate the type of taxes Or miscellaneous charge.
    /// </summary>
    [JsonProperty("taxesOrMiscellaneousChargeType")]
    public string? TaxesOrMiscellaneousChargeType { get; set; }
    /// <summary>
    /// Indicate the freight charge.
    /// </summary>
    [JsonProperty("freightCharge")]
    public FreightCharge? FreightCharge { get; set; }
    /// <summary>
    /// Indicate the packing cost.
    /// </summary>
    [JsonProperty("packingCosts")]
    public PackingCosts? PackingCosts { get; set; }
    /// <summary>
    /// Indicate the handling cost.
    /// </summary>
    [JsonProperty("handlingCosts")]
    public HandlingCosts? HandlingCosts { get; set; }
    /// <summary>
    /// Specify insurance charges if applicable.
    /// </summary>
    [JsonProperty("insuranceCharge")]
    public InsuranceCharge? InsuranceCharge { get; set; }
    /// <summary>
    /// This is the declaration statement which will populate the Commercial Invoice (or Pro Forma).
    /// </summary>
    [JsonProperty("declarationStatement")]
    public string? DeclarationStatement { get; set; }
    /// <summary>
    /// Specify terms Of Sale that will be populated on the Commercial Invoice (or Pro Forma). Maximum length is 3
    /// </summary>
    [JsonProperty("termsOfSale")]
    public string? TermsOfSale { get; set; }
    /// <summary>
    /// These are special instructions that will be populated on the Commercial Invoice (or Pro Forma).
    /// </summary>
    [JsonProperty("specialInstructions")]
    public string? SpecialInstructions { get; set; }
    /// <summary>
    /// This is the reason for the shipment.
    /// </summary>
    [JsonProperty("shipmentPurpose")]
    public string? ShipmentPurpose { get; set; }
    /// <summary>
    /// These are email disposition details. Provides the type and email addresses of e-mail recipients. If returnedDispositionDetail in labelSpecification is set as true then email will be send with label and documents copy.
    /// </summary>
    [JsonProperty("emailNotificationDetail")]
    public EmailNotificationDetail? EmailNotificationDetail { get; set; }
}

public class CommercialInvoiceDetail
{
    [JsonProperty("customerImageUsages")]
    public List<CustomerImageUsage>? CustomerImageUsages { get; set; }

    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
}

public class Commodity
{
    /// <summary>
    /// This is the unit price.
    /// </summary>
    [JsonProperty("unitPrice")]
    public UnitPrice? UnitPrice { get; set; }
    /// <summary>
    /// This object contains additional quantitative information other than weight and quantity to calculate duties and taxes.
    /// </summary>

    [JsonProperty("additionalMeasures")]
    public List<AdditionalMeasure>? AdditionalMeasures { get; set; }
    /// <summary>
    ///Indicate the number of pieces associated with the commodity. The value can neither be negative nor exceed 9,999.
    /// </summary>
    [JsonProperty("numberOfPieces")]
    public int? NumberOfPieces { get; set; }
    /// <summary>
    /// This is the units quantity (using quantityUnits as the unit of measure) per commodity. This is used to estimate duties and taxes.
    /// </summary>
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
    /// <summary>
    /// This is the unit of measure for the units quantity. This is used to estimate duties and taxes.
    /// </summary>
    [JsonProperty("quantityUnits")]
    public string? QuantityUnits { get; set; }
    /// <summary>
    /// This customs value is applicable for all items(or units) under the specified commodity.
    /// </summary>
    [JsonProperty("customsValue")]
    public CustomsValue? CustomsValue { get; set; }
    /// <summary>
    ///This is commodity country of manufacture. This is required for International shipments. Maximum allowed length is 4.
    /// </summary>
    [JsonProperty("countryOfManufacture")]
    public string? CountryOfManufacture { get; set; }
    /// <summary>
    /// This is an identifying mark or number used on the packaging of a shipment to help customers identify a particular shipment
    /// </summary>
    [JsonProperty("cIMarksAndNumbers")]
    public string? CIMarksAndNumbers { get; set; }
    /// <summary>
    /// This is to specify the Harmonized Tariff System (HTS) code to meet U.S. and foreign governments' customs requirements. These are mainly used to estimate the duties and taxes.
    /// </summary>
    [JsonProperty("harmonizedCode")]
    public string? HarmonizedCode { get; set; }
    /// <summary>
    /// This is the commodity description. Maximum allowed 450 characters.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
    /// <summary>
    /// This is Commodity name.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
    /// <summary>
    /// It is the unit weight of the commodity.
    /// </summary>
    [JsonProperty("weight")]
    public Weight? Weight { get; set; }
    /// <summary>
    /// This is the export license number for the shipment.
    /// </summary>
    [JsonProperty("exportLicenseNumber")]
    public string? ExportLicenseNumber { get; set; }
    /// <summary>
    /// Specify the export license expiration date for the shipment.
    /// </summary>
    [JsonProperty("exportLicenseExpirationDate")]
    public DateTime? ExportLicenseExpirationDate { get; set; }
    [JsonProperty("exportLicenseDetail")]
    public ExportLicenseDetail? ExportLicenseDetail { get; set; }
    /// <summary>
    /// This is a part number.
    /// </summary>
    [JsonProperty("partNumber")]
    public string? PartNumber { get; set; }
    /// <summary>
    /// This is the purpose of this shipment. This is used for calculation of duties and taxes.
    /// </summary>
    [JsonProperty("purpose")]
    public string? Purpose { get; set; }
    /// <summary>
    /// Indicates the USMCA detail
    /// </summary>
    [JsonProperty("usmcaDetail")]
    public UsmcaDetail? UsmcaDetail { get; set; }
}

public class ExportLicenseDetail
{
    [JsonProperty("expirationDate")]
    public string? ExpirationDate { get; set; }
    [JsonProperty("number")]
    public string? Number { get; set; }
}

public class Contact
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

public class ContentRecord
{
    /// <summary>
    /// This is a package item number.
    /// </summary>
    [JsonProperty("itemNumber")]
    public string? ItemNumber { get; set; }
    /// <summary>
    /// This is the package item quantity.
    /// </summary>
    [JsonProperty("receivedQuantity")]
    public int? ReceivedQuantity { get; set; }
    /// <summary>
    /// This is the description of the package item.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
    /// <summary>
    /// This is the part number.
    /// </summary>
    [JsonProperty("partNumber")]
    public string? PartNumber { get; set; }
}

public class CustomerImageUsage
{
    /// <summary>
    /// Specify the Image ID.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }
    /// <summary>
    /// Specify document image type.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
    /// <summary>
    /// Specify the provided document image type.
    /// </summary>
    [JsonProperty("providedImageType")]
    public string? ProvidedImageType { get; set; }
}

public class CustomerReference
{
    /// <summary>
    /// This is a customer reference type. The value specified here for the element is printed on the Commercial Invoice only for tracking and label information.
    /// </summary>
    [JsonProperty("customerReferenceType")]
    public string? CustomerReferenceType { get; set; }
    /// <summary>
    /// This is a customer reference type value.
    /// </summary>
    [JsonProperty("value")]
    public string? Value { get; set; }
}

public class CustomerSpecifiedDetail
{
    /// <summary>
    /// Specify which data/sections on the label to be masked.
    /// </summary>
    [JsonProperty("maskedData")]
    public List<string>? MaskedData { get; set; }
    /// <summary>
    /// Specify how the regulatory details to be provided on the labels.
    /// </summary>
    [JsonProperty("regulatoryLabels")]
    public List<RegulatoryLabel> RegulatoryLabels { get; set; }
    /// <summary>
    /// Specify how the additional details to be provided on the labels.
    /// </summary>
    [JsonProperty("additionalLabels")]
    public List<AdditionalLabel>? AdditionalLabels { get; set; }
    /// <summary>
    /// Specifies details of doc tab content.It is only applicable only with imageType as ZPLII.
    /// </summary>
    [JsonProperty("docTabContent")]
    public DocTabContent? DocTabContent { get; set; }
}

public class CustomsClearanceDetail
{
    /// <summary>
    /// These are the regulatory controls applicable to the shipment.
    /// </summary>
    [JsonProperty("regulatoryControls")]
    public string? RegulatoryControls { get; set; }
    /// <summary>
    /// Specify broker information. Use this option only if you are using Broker Select Option for your shipment. A country code must be specified in addition to one of the following address items: postal code, city, or location id.
    /// </summary>
    [JsonProperty("brokers")]
    public List<Brokers>? Brokers { get; set; }
    /// <summary>
    /// Use this object to provide Commercial Invoice details. This element is required for electronic upload of CI data. It will serve to create/transmit an electronic Commercial Invoice through the FedEx system.
    /// </summary>
    [JsonProperty("commercialInvoice")]
    public CommercialInvoice? CommercialInvoice { get; set; }
    /// <summary>
    /// Specify the risk owner for the Freight shipment.This element is only mandatory or valid for Intra India shipments.
    /// </summary>
    [JsonProperty("freightOnValue")]
    public string? FreightOnValue { get; set; }
    /// <summary>
    /// This is a payment type, basically indicates who is the payor for the shipment.Conditional required for International Shipments
    /// </summary>
    [JsonProperty("dutiesPayment")]
    public DutiesPayment? DutiesPayment { get; set; }
    [JsonProperty("documentContent")]
    public string? DocumentContent { get; set; }
    /// <summary>
    /// Indicates the details about the dutiable packages. Maximum upto 999 commodities per shipment.
    /// </summary>
    [JsonProperty("commodities")]
    public List<Commodity>? Commodities { get; set; }
    /// <summary>
    /// Used to specify if a shipment is document shipment or not. Used only for International Express document shipments. Default value is false.
    /// </summary>
    [JsonProperty("isDocumentOnly")]
    public bool? IsDocumentOnly { get; set; }
    /// <summary>
    /// Use this element to provide valid identification details. Used for populating brazil tax id.
    /// </summary>
    [JsonProperty("recipientCustomsId")]
    public RecipientCustomsId? RecipientCustomsId { get; set; }
    /// <summary>
    /// These are customs Option Detail, type must be indicated for each occurrence.
    /// </summary>
    [JsonProperty("customsOption")]
    public CustomsOption? CustomsOption { get; set; }
    /// <summary>
    /// The descriptive data for the importer of Record for the shipment and their physical address, contact and account number information.
    /// </summary>
    [JsonProperty("importerOfRecord")]
    public ImporterOfRecord? ImporterOfRecord { get; set; }
    /// <summary>
    /// This is the locale for generated document.
    /// </summary>
    [JsonProperty("generatedDocumentLocale")]
    public string? GeneratedDocumentLocale { get; set; }
    /// <summary>
    /// These are export Detail used for US or CA exports.
    /// </summary>
    [JsonProperty("exportDetail")]
    public ExportDetail? ExportDetail { get; set; }
    /// <summary>
    /// This is the total customs value.
    /// </summary>
    [JsonProperty("totalCustomsValue")]
    public TotalCustomsValue? TotalCustomsValue { get; set; }
    /// <summary>
    /// Specify if the transacting parties are related.
    /// </summary>
    [JsonProperty("partiesToTransactionAreRelated")]
    public bool? PartiesToTransactionAreRelated { get; set; }
    /// <summary>
    /// Specifies about the statements to be declared for Customs.
    /// </summary>
    [JsonProperty("declarationStatementDetail")]
    public DeclarationStatementDetail? DeclarationStatementDetail { get; set; }
    /// <summary>
    /// Specify insurance charges if applicable.
    /// </summary>
    [JsonProperty("insuranceCharge")]
    public InsuranceCharge? InsuranceCharge { get; set; }
}

public class CustomsOption
{
    /// <summary>
    /// Specify additional description about customs options. This is a required field when the Type is OTHER.
    /// </summary>
    [JsonProperty("description")]
    public string? Description { get; set; }
    /// <summary>
    /// Specify the reason for a global return, as recognized by Customs.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
}

public class CustomsValue
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class DangerousGoodsDetail
{
    /// <summary>
    /// A Boolean value that, when True, specifies the mode of shipment transportation should be Cargo Aircraft for Dangerous Goods. Its default value is set as False.
    /// </summary>
    [JsonProperty("cargoAircraftOnly")]
    public bool? CargoAircraftOnly { get; set; }
    /// <summary>
    /// Specify Dangerous Goods Accessibility Type.
    /// </summary>
    [JsonProperty("accessibility")]
    public string? Accessibility { get; set; }
    /// <summary>
    /// Indicate type of DG being reported.
    /// </summary>
    [JsonProperty("options")]
    public List<string>? Options { get; set; }
}

public class DeclarationStatementDetail
{
    /// <summary>
    /// Specifies about the statements to be declared for Customs.
    /// </summary>
    [JsonProperty("usmcaLowValueStatementDetail")]
    public UsmcaLowValueStatementDetail? UsmcaLowValueStatementDetail { get; set; }
}

public class DeclaredValue
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class DeliveryOnInvoiceAcceptanceDetail
{
    /// <summary>
    /// The descriptive data for the recipient of the shipment and the physical location for the shipment destination.
    /// </summary>
    [JsonProperty("recipient")]
    public Recipient? Recipient { get; set; }
}

public class DestinationControlDetail
{
    /// <summary>
    /// Specify End User name. Its is required if StatementTypes is entered as DEPARTMENT_OF_STATE.
    /// </summary>
    [JsonProperty("endUser")]
    public string? EndUser { get; set; }
    /// <summary>
    /// Specify appropriate destination control statement type(s), Also make sure to specify destination country and end user.
    /// </summary>
    [JsonProperty("statementTypes")]
    public string? StatementTypes { get; set; }
    /// <summary>
    /// Specify DCS shipment destination country. You may enter up to four country codes in this element. Up to 11 alphanumeric characters are allowed.
    /// </summary>
    [JsonProperty("destinationCountries")]
    public List<string>? DestinationCountries { get; set; }
}

public class Dimensions
{
    /// <summary>
    /// Indicate the length of the package. No implied decimal places. Maximum value: 999
    /// </summary>
    [JsonProperty("length")]
    public int? Length { get; set; }
    /// <summary>
    /// Indicate the width of the package. No implied decimal places. Maximum value: 999
    /// </summary>
    [JsonProperty("width")]
    public int? Width { get; set; }
    /// <summary>
    /// Indicate the height of the package. No implied decimal places. Maximum value: 999
    /// </summary>
    [JsonProperty("height")]
    public int? Height { get; set; }
    /// <summary>
    /// Indicate the Unit of measure for the provided dimensions.
    /// </summary>
    [JsonProperty("units")]
    public string? Units { get; set; }
}

public class Disposition
{
    /// <summary>
    /// Specifies how to e-mail shipping documents.
    /// </summary>
    [JsonProperty("eMailDetail")]
    public EMailDetail? EMailDetail { get; set; }
    /// <summary>
    /// Specify how to create and return the document.
    /// </summary>
    [JsonProperty("dispositionType")]
    public string? DispositionType { get; set; }
}

public class DocTabContent
{
    /// <summary>
    /// Indicates the content type of the doc tab.
    /// </summary>
    [JsonProperty("docTabContentType")]
    public string? DocTabContentType { get; set; }
    /// <summary>
    /// Indicate the doc tab specification for different zones on the label. The specification includes zone number, header and data field to be displayed on the label.
    /// </summary>

    [JsonProperty("zone001")]
    public Zone001? Zone001 { get; set; }
    /// <summary>
    /// It is a doc tab content type which is in barcoded format.
    /// </summary>
    [JsonProperty("barcoded")]
    public Barcoded? Barcoded { get; set; }
}

public class DocTabZoneSpecification
{
    /// <summary>
    /// It is a non-negative integer that represents the portion of doc-tab in a label.
    /// </summary>
    [JsonProperty("zoneNumber")]
    public int? ZoneNumber { get; set; }
    /// <summary>
    /// Indicates the parameter name in the header for the doc tab zone. The maximum charater limit is 7.
    /// </summary>
    [JsonProperty("header")]
    public string? Header { get; set; }
    /// <summary>
    /// Indicate the path request/reply element to be printed on doc tab.
    /// </summary>
    [JsonProperty("dataField")]
    public string? DataField { get; set; }
    /// <summary>
    /// Indicates the actual data to be printed in the label
    /// </summary>
    [JsonProperty("literalValue")]
    public string? LiteralValue { get; set; }
    /// <summary>
    /// Indicates the justification format for the string?.
    /// </summary>
    [JsonProperty("justification")]
    public string? Justification { get; set; }
}

public class DocumentFormat
{
    /// <summary>
    /// Use this element to indicate whether or not to provide the instructions.
    /// </summary>
    [JsonProperty("provideInstructions")]
    public bool? ProvideInstructions { get; set; }
    /// <summary>
    /// Indicate the requested options for document format.
    /// </summary>
    [JsonProperty("optionsRequested")]
    public OptionsRequested? OptionsRequested { get; set; }
    /// <summary>
    /// Specify the label stock type.
    /// </summary>
    [JsonProperty("stockType")]
    public string? StockType { get; set; }
    /// <summary>
    /// Details on creating, organizing, and returning the document.
    /// </summary>
    [JsonProperty("dispositions")]
    public List<Disposition>? Dispositions { get; set; }
    /// <summary>
    /// These are locale details.
    /// </summary>
    [JsonProperty("locale")]
    public string? Locale { get; set; }
    /// <summary>
    /// Specify the image format used for shipping document.
    /// </summary>
    [JsonProperty("docType")]
    public string? DocType { get; set; }
}

public class DryIceWeight
{
    /// <summary>
    /// Indicate the weight unit type. The package and commodity weight unit should be the same else the request will result in an error.
    /// </summary>
    [JsonProperty("units")]
    public string? Units { get; set; }
    /// <summary>
    ///Weight Value.
    /// </summary>
    [JsonProperty("value")]
    public int? Value { get; set; }
}

public class DutiesPayment
{
    /// <summary>
    /// Information about the person who is paying for the shipment. Not applicable for credit card payment.
    /// </summary>
    [JsonProperty("payor")]
    public Payor? Payor { get; set; }

    /// <summary>
    ///These are billing details.
    /// </summary>
    [JsonProperty("billingDetails")]
    public BillingDetails? BillingDetails { get; set; }
    /// <summary>
    /// This is a payment type, basically indicates who is the payor for the shipment.
    /// </summary>
    [JsonProperty("paymentType")]
    public string? PaymentType { get; set; }
}

public class EMailDetail
{
    /// <summary>
    /// Indicates the shipping document email recipients.
    /// </summary>
    [JsonProperty("eMailRecipients")]
    public List<EMailRecipient>? EMailRecipients { get; set; }
    /// <summary>
    /// These are locale details.
    /// </summary>
    [JsonProperty("locale")]
    public string? Locale { get; set; }
    /// <summary>
    /// Identifies the convention by which documents are to be grouped as email attachment.
    /// </summary>
    [JsonProperty("grouping")]
    public string? Grouping { get; set; }
}

public class EmailLabelDetail
{
    /// <summary>
    /// This is Email label recipient email address, shipment role, & language locale details. Atleast one entry must be specified.
    /// </summary>
    [JsonProperty("recipients")]
    public List<Recipient>? Recipients { get; set; }
    /// <summary>
    /// This is an optional personalized message to be included in the email to the recipient.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }
}

/// <summary>
/// This is used to provide eMail notification information
/// </summary>
public class EmailNotificationDetail
{
    /// <summary>
    /// This is the shipment Notification Aggregation Type.
    /// </summary>
    [JsonProperty("aggregationType")]
    public string? AggregationType { get; set; }
    /// <summary>
    /// These are email notification recipient details.
    /// </summary>
    [JsonProperty("emailNotificationRecipients")]
    public List<EmailNotificationRecipient>? EmailNotificationRecipients { get; set; }
    /// <summary>
    /// This is your personal message for the email.
    /// </summary>
    [JsonProperty("personalMessage")]
    public string? PersonalMessage { get; set; }

}

public class EmailNotificationRecipient
{
    /// <summary>
    /// Specify the recipient name.
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; set; }
    /// <summary>
    /// Specify the recipient type for email notification.
    /// </summary>
    [JsonProperty("emailNotificationRecipientType")]
    public string? EmailNotificationRecipientType { get; set; }
    /// <summary>
    /// Specify the recipient email address.
    /// </summary>
    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }
    /// <summary>
    /// This is the format for the email notification. Either HTML or plain text can be provided.
    /// </summary>
    [JsonProperty("notificationFormatType")]
    public string? NotificationFormatType { get; set; }
    /// <summary>
    /// Indicate the type of notification that will be sent as an email
    /// </summary>
    [JsonProperty("notificationType")]
    public string? NotificationType { get; set; }
    /// <summary>
    /// These are the locale details for email.
    /// </summary>
    [JsonProperty("locale")]
    public string? Locale { get; set; }
    /// <summary>
    ///These are to specify the notification event types.
    /// </summary>
    [JsonProperty("notificationEventType")]
    public List<string>? NotificationEventType { get; set; }
}

public class EMailRecipient
{
    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonProperty("recipientType")]
    public string? RecipientType { get; set; }
}

public class EtdDetail
{
    /// <summary>
    /// Use this attribute to specify if the Trade documents will be uploaded post the shipment.
    /// </summary>
    [JsonProperty("attributes")]
    public List<string>? Attributes { get; set; }
    /// <summary>
    /// Use this object to specify the details regarding already uploded document(s). 
    /// </summary>
    [JsonProperty("attachedDocuments")]
    public List<AttachedDocument>? AttachedDocuments { get; set; }
    /// <summary>
    /// Indicate the types of shipping documents produced for the shipper by FedEx. 
    /// </summary>
    [JsonProperty("requestedDocumentTypes")]
    public List<string>? RequestedDocumentTypes { get; set; }
}

public class ExportDetail
{
    /// <summary>
    /// Use this object to specify the appropriate destination control statement type(s). Also make sure to specify destination country and end user.
    /// </summary>
    [JsonProperty("destinationControlDetail")]
    public DestinationControlDetail? DestinationControlDetail { get; set; }
    /// <summary>
    /// Specify the filing option being exercised. Required for non-document shipments originating in Canada destinated for any country other than Canada, the United States, Puerto Rico, or the U.S. Virgin Islands.
    /// </summary>
    [JsonProperty("b13AFilingOption")]
    public string? B13AFilingOption { get; set; }
    /// <summary>
    /// For US export shipments requiring an EEI, enter the ITN number received from AES when you filed your shipment or the FTR (Foreign Trade Regulations) exemption number.The proper format for an ITN number is AES XYYYYMMDDNNNNNN where YYYYMMDD is date and NNNNNN are numbers generated by the AES.
    /// </summary>
    [JsonProperty("exportComplianceStatement")]
    public string? ExportComplianceStatement { get; set; }
    /// <summary>
    /// This is a Permit Number. This field is applicable only to Canada export non-document shipments of any value to any destination. No special characters are allowed.
    /// </summary>
    [JsonProperty("permitNumber")]
    public string? PermitNumber { get; set; }
}

public class ExpressFreightDetail
{
    /// <summary>
    /// This is an advanced booking number that must be acquired through the appropriate channel in the shipment origin country. Without the booking number pickup and space allocation for the Express Freight shipment are not guaranteed.
    /// </summary>
    [JsonProperty("bookingConfirmationNumber")]
    public string? BookingConfirmationNumber { get; set; }
    /// <summary>
    /// Indicates the content of a container were loaded and counted by the shipper.
    /// </summary>
    [JsonProperty("shippersLoadAndCount")]
    public int? ShippersLoadAndCount { get; set; }
    /// <summary>
    /// This indicates whether or not the Packing List is enclosed with the shipment. A packing list is a document that includes details about the contents of a package.
    /// </summary>
    [JsonProperty("packingListEnclosed")]
    public bool? PackingListEnclosed { get; set; }
}

public class FinancialInstitutionContactAndAddress
{
    /// <summary>
    /// This is detailed information on physical location. 
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// Indicate the contact details of the shipper.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
}

public class FixedValue
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class FreightCharge
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class GeneralAgencyAgreementDetail
{
    /// <summary>
    /// Specify the shipping document format.
    /// </summary>
    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
}

public class HandlingCosts
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    ///This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class HoldAtLocationDetail
{
    /// <summary>
    /// This is an alphanumeric identifier used for Location/Facility Identification.
    /// </summary>
    [JsonProperty("locationId")]
    public string? LocationId { get; set; }
    /// <summary>
    /// Specifies the contact and address details of a location.
    /// </summary>
    [JsonProperty("locationContactAndAddress")]
    public LocationContactAndAddress? LocationContactAndAddress { get; set; }
    /// <summary>
    /// Specifies the type of facility at which package/shipment is to be held.
    /// </summary>
    [JsonProperty("locationType")]
    public string? LocationType { get; set; }
}

public class HomeDeliveryPremiumDetail
{
    /// <summary>
    /// Indicate the phone number. Only numeric values allowed.
    /// </summary>
    [JsonProperty("phoneNumber")]
    public PhoneNumber? PhoneNumber { get; set; }
    /// <summary>
    /// This is delivery date. Required for FedEx Date Certain Home Delivery.
    /// </summary>
    [JsonProperty("deliveryDate")]
    public string? DeliveryDate { get; set; }
    /// <summary>
    /// This is Home Delivery Premium Type. It allows to specify additional premimum service options for the home delivery shipment. 
    /// </summary>
    [JsonProperty("homedeliveryPremiumType")]
    public string? HomedeliveryPremiumType { get; set; }
}

public class ImporterOfRecord
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// This is FedEx Account number details.
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
}

public class InsuranceCharge
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class InternationalControlledExportDetail
{
    /// <summary>
    /// Indicate the expiration date for the license or permit. The format is YYYY-MM-DD.
    /// </summary>
    [JsonProperty("licenseOrPermitExpirationDate")]
    public string? LicenseOrPermitExpirationDate { get; set; }
    /// <summary>
    /// Indicate License Or Permit Number for the commodity being exported.
    /// </summary>
    [JsonProperty("licenseOrPermitNumber")]
    public string? LicenseOrPermitNumber { get; set; }
    /// <summary>
    /// Indicate Entry Number for the export.
    /// </summary>
    [JsonProperty("entryNumber")]
    public string? EntryNumber { get; set; }
    /// <summary>
    /// Indicate the Foreign Trade Zone Code.
    /// </summary>
    [JsonProperty("foreignTradeZoneCode")]
    public string? ForeignTradeZoneCode { get; set; }
    /// <summary>
    /// Indicate International Controlled Export Type.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
}

public class InternationalTrafficInArmsRegulationsDetail
{
    /// <summary>
    /// The export or license number for the ITAR shipment.
    ///Minimum length is 5 characters.
    ///Maximum length is 21 characters.
    /// </summary>
    [JsonProperty("licenseOrExemptionNumber")]
    public string? LicenseOrExemptionNumber { get; set; }
}

public class LabelSpecification
{
    /// <summary>
    /// Specify the label Format Type.
    /// </summary>
    [JsonProperty("labelFormatType")]
    public string? LabelFormatType { get; set; }
    /// <summary>
    /// This is the order of the Shipping label/documents to be generated.
    /// </summary>
    [JsonProperty("labelOrder")]
    public string? LabelOrder { get; set; }
    /// <summary>
    /// This object allows the control of label content for customization.
    /// </summary>
    [JsonProperty("customerSpecifiedDetail")]
    public CustomerSpecifiedDetail? CustomerSpecifiedDetail { get; set; }
    /// <summary>
    /// Specifies the contact and address details of a location.
    /// </summary>
    [JsonProperty("printedLabelOrigin")]
    public PrintedLabelOrigin? PrintedLabelOrigin { get; set; }
    /// <summary>
    /// Indicate the label stock type used.
    /// </summary>
    [JsonProperty("labelStockType")]
    public string? LabelStockType { get; set; }
    /// <summary>
    /// This is applicable only to documents produced on thermal printers with roll stock.
    /// </summary>
    [JsonProperty("labelRotation")]
    public string? LabelRotation { get; set; }
    /// <summary>
    /// Specify the image format used for a shipping document.
    /// </summary>
    [JsonProperty("imageType")]
    public string? ImageType { get; set; }
    /// <summary>
    /// This is applicable only to documents produced on thermal printers with roll stock.
    /// </summary>
    [JsonProperty("labelPrintingOrientation")]
    public string? LabelPrintingOrientation { get; set; }
    /// <summary>
    /// Specify whether or not the return deposition is needed.
    /// </summary>
    [JsonProperty("returnedDispositionDetail")]
    public bool? ReturnedDispositionDetail { get; set; }
    [JsonProperty("autoPrint")]
    public bool? AutoPrint { get; set; }
}

public class LocationContactAndAddress
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details of the shipper.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
}

public class MasterTrackingId
{
    /// <summary>
    /// This is FedEx tracking Identifier associated with the package.
    /// </summary>
    [JsonProperty("formId")]
    public string? FormId { get; set; }
    /// <summary>
    /// Specify the FedEx transportation type.
    /// </summary>
    [JsonProperty("trackingIdType")]
    public string? TrackingIdType { get; set; }
    /// <summary>
    /// Specify the USPS tracking Identifier associated with FedEx SmartPost shipment.
    /// </summary>
    [JsonProperty("uspsApplicationId")]
    public string? UspsApplicationId { get; set; }
    /// <summary>
    /// This is the number associated with the package that is used to track it.
    /// </summary>
    [JsonProperty("trackingNumber")]
    public string? TrackingNumber { get; set; }
}

public class Op900Detail
{
    [JsonProperty("customerImageUsages")]
    public List<CustomerImageUsage>? CustomerImageUsages { get; set; }

    [JsonProperty("signatureName")]
    public string? SignatureName { get; set; }

    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
}

public class OptionsRequested
{
    /// <summary>
    /// These are the processing options.
    /// </summary>
    [JsonProperty("options")]
    public List<string>? Options { get; set; }
}

public class Origin
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details of the shipper.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
}

public class PackageCODDetail
{
    /// <summary>
    /// Indicate the COD collection amount.
    /// </summary>
    [JsonProperty("codCollectionAmount")]
    public CodCollectionAmount? CodCollectionAmount { get; set; }
}

public class PackageSpecialServices
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

public class PackingCosts
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class Payor
{
    /// <summary>
    /// Use this object to provide the attributes such as physical address, contact information and account number information.
    /// </summary>
    [JsonProperty("responsibleParty")]
    public ResponsibleParty? ResponsibleParty { get; set; }
}

public class PendingShipmentDetail
{
    /// <summary>
    /// This is Pending Shipment Type. Must include the value 'EMAIL' for email return shipments.
    ///Not applicable for other types of shipments.
    /// </summary>
    [JsonProperty("pendingShipmentType")]
    public string? PendingShipmentType { get; set; }
    /// <summary>
    /// Use this object to allow the Email Label shipment originator, specify if the Email label shipment completer can make modifications to editable shipment data.
    /// </summary>
    [JsonProperty("processingOptions")]
    public ProcessingOptions? ProcessingOptions { get; set; }
    /// <summary>
    /// These are documents that are recommended to be included with the shipment.
    /// </summary>
    [JsonProperty("recommendedDocumentSpecification")]
    public RecommendedDocumentSpecification? RecommendedDocumentSpecification { get; set; }
    /// <summary>
    /// These are specific information about the pending email label.
    ///Required when PendingShipmentType is EMAIL.
    /// </summary>
    [JsonProperty("emailLabelDetail")]
    public EmailLabelDetail? EmailLabelDetail { get; set; }
    /// <summary>
    /// These are specific information about the pending email label.
    ///Required when PendingShipmentType is EMAIL.
    /// </summary>
    [JsonProperty("attachedDocuments")]
    public List<AttachedDocument>? AttachedDocuments { get; set; }
    /// <summary>
    /// This is the Email Label expiration date. The maximum expiration date for an Email Return Label must be greater of equal to the day of the label request and not greater than 2 years in the future.
    /// </summary>
    [JsonProperty("expirationTimeStamp")]
    public string? ExpirationTimeStamp { get; set; }
}

public class PhoneNumber
{
    [JsonProperty("areaCode")]
    public string? AreaCode { get; set; }

    [JsonProperty("localNumber")]
    public string? LocalNumber { get; set; }

    [JsonProperty("extension")]
    public string? Extension { get; set; }

    [JsonProperty("personalIdentificationNumber")]
    public string? PersonalIdentificationNumber { get; set; }
}

public class PrintedLabelOrigin
{
    [JsonProperty("address")]
    public Address? Address { get; set; }

    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
}

public class PriorityAlertDetail
{
    /// <summary>
    /// The types of all enhancement for the Priority Alert.
    /// </summary>
    [JsonProperty("enhancementTypes")]
    public List<string>? EnhancementTypes { get; set; }
    /// <summary>
    /// Specifies Content for the Priority Alert Detail.
    /// </summary>
    [JsonProperty("content")]
    public List<string>? Content { get; set; }
}

public class ProcessingOptions
{
    /// <summary>
    /// These are processing options.
    /// </summary>
    [JsonProperty("options")]
    public List<string>? Options { get; set; }
}

public class Producer
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
}

public class Recipient
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
    /// <summary>
    /// Specify the delivery instructions to be added with the shipment.
    /// </summary>
    [JsonProperty("deliveryInstructions")]
    public string? DeliveryInstructions { get; set; }
    /// <summary>
    /// This is recipient email address for notifying the return label. Maximum length 200 characters.
    /// </summary>

    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }
    /// <summary>
    /// These are to indicate how the email notifications for the pending shipment to be processed.
    /// </summary>
    [JsonProperty("optionsRequested")]
    public OptionsRequested? OptionsRequested { get; set; }
    /// <summary>
    /// This is to specify Recipient role in the shipment.Shipment completor role is needed when we pass shipment initiator. We cannot use shipment initiator alone.
    /// </summary>
    [JsonProperty("role")]
    public string? Role { get; set; }
    /// <summary>
    /// These are locale details.
    /// </summary>
    [JsonProperty("locale")]
    public string? Locale { get; set; }
}

public class Recipient2
{
    [JsonProperty("address")]
    public Address? Address { get; set; }

    [JsonProperty("contact")]
    public Contact? Contact { get; set; }

    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }

    [JsonProperty("deliveryInstructions")]
    public string? DeliveryInstructions { get; set; }
}

public class RecipientCustomsId
{
    /// <summary>
    /// This is ID Type.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
    /// <summary>
    /// This is the ID number.
    /// </summary>
    [JsonProperty("value")]
    public string? Value { get; set; }
}

public class RecommendedDocumentSpecification
{
    /// <summary>
    /// This is the recommended document Type.
    /// </summary>
    [JsonProperty("types")]
    public string? Types { get; set; }
}

public class RegulatoryLabel
{
    /// <summary>
    /// Specify the regulatory content preference to be displayed on the label.
    /// </summary>
    [JsonProperty("generationOptions")]
    public string? GenerationOptions { get; set; }
    /// <summary>
    /// Specify the type of regulatory content to be added on the label.
    /// </summary>
    [JsonProperty("type")]
    public string? Type { get; set; }
}

public class RequestedPackageLineItem
{
    /// <summary>
    /// Used only with individual packages as a unique identifier of each requested package. Will be adjusted at the shipment level as pieces are added.
    /// </summary>
    [JsonProperty("sequenceNumber")]
    public int? SequenceNumber { get; set; }
    /// <summary>
    /// Indicate the subPackagingType, if you are using your own packaging for the shipment.
    /// </summary>
    [JsonProperty("subPackagingType")]
    public string? SubPackagingType { get; set; }
    /// <summary>
    /// This object lists the customer references provided with the package.
    /// </summary>
    [JsonProperty("customerReferences")]
    public List<CustomerReference>? CustomerReferences { get; set; }
    /// <summary>
    /// This is the Declared Value of any shipment which represents FedEx maximum liability associated with a shipment.
    /// </summary>
    [JsonProperty("declaredValue")]
    public DeclaredValue? DeclaredValue { get; set; }
    /// <summary>
    /// These are the package weight details.
    /// </summary>
    [JsonProperty("weight")]
    public Weight? Weight { get; set; }
    /// <summary>
    /// Indicate the dimensions of the package.
    /// </summary>
    [JsonProperty("dimensions")]
    public Dimensions? Dimensions { get; set; }
    /// <summary>
    /// Indicate the grouped package count. These are number of identical package(s) each with one or more commodities.
    /// </summary>
    [JsonProperty("groupPackageCount")]
    public int? GroupPackageCount { get; set; }
    /// <summary>
    /// Describe the content of the package for customs clearance purposes. This applies to intra-UAE, intra-Columbia and intra-Brazil shipments.
    /// </summary>
    [JsonProperty("itemDescriptionForClearance")]
    public string? ItemDescriptionForClearance { get; set; }
    /// <summary>
    /// Use this object to specify package content details.
    /// </summary>
    [JsonProperty("contentRecord")]
    public List<ContentRecord>? ContentRecord { get; set; }
    /// <summary>
    /// This the item description for the package.
    /// </summary>
    [JsonProperty("itemDescription")]
    public string? ItemDescription { get; set; }
    /// <summary>
    /// Indicate the details about how to calculate variable handling charges at the shipment level. 
    /// </summary>
    [JsonProperty("variableHandlingChargeDetail")]
    public VariableHandlingChargeDetail? VariableHandlingChargeDetail { get; set; }
    /// <summary>
    /// These are special services that are available at the package level for some or all service types.
    /// </summary>
    [JsonProperty("packageSpecialServices")]
    public PackageSpecialServices? PackageSpecialServices { get; set; }
}

public class RequestedShipment
{
    /// <summary>
    /// This is the shipment date. Default value is current date in case the date is not provided or a past date is provided.
    /// </summary>
    [JsonProperty("shipDatestamp")]
    public string? ShipDatestamp { get; set; }
    /// <summary>
    /// It is the sum of all declared values of all packages in a shipment. The amount of totalDeclaredValue must be equal to the sum of all the individual declaredValues in the shipment. The declaredValue and totalDeclaredValue must match in all currencies in one shipment. This value represents FedEx maximum liability associated with a shipment. This is including, but not limited to any loss, damage, delay, misdelivery, any failure to provide information, or misdelivery of information related to the Shipment
    /// </summary>

    [JsonProperty("totalDeclaredValue")]
    public TotalDeclaredValue? TotalDeclaredValue { get; set; }
    /// <summary>
    /// Indicate the Shipper contact details for this shipment.
    /// </summary>

    [JsonProperty("shipper")]
    public Shipper? Shipper { get; set; }
    /// <summary>
    /// Will indicate the party responsible for purchasing the goods shipped from the shipper to the recipient. The sold to party is not necessarily the recipient or the importer of record. The sold to party is relevant when the purchaser, rather than the recipient determines when certain customs regulations apply
    /// </summary>
    [JsonProperty("soldTo")]
    public SoldTo? SoldTo { get; set; }
    /// <summary>
    /// Indicate the descriptive data for the recipient location to which the shipment is to be received.
    /// </summary>
    [JsonProperty("recipients")]
    public List<Recipient>? Recipients { get; set; }
    /// <summary>
    /// A unique identifier for a recipient location.
    /// </summary>

    [JsonProperty("recipientLocationNumber")]
    public string? RecipientLocationNumber { get; set; }

    /// <summary>
    /// Indicate the pickup type method by which the shipment to be tendered to FedEx.
    /// </summary>
    [JsonProperty("pickupType")]
    public string? PickupType { get; set; }
    [JsonProperty("edtRequestType")]
    public string? EdtRequestType { get; set; }
    /// <summary>
    /// Indicate the FedEx service type used for this shipment.
    /// </summary>

    [JsonProperty("serviceType")]
    public string? ServiceType { get; set; }
    /// <summary>
    /// Specify the packaging used.
    /// </summary>

    [JsonProperty("packagingType")]
    public string? PackagingType { get; set; }
    /// <summary>
    /// Indicate the shipment total weight in pounds.
    /// </summary>

    [JsonProperty("totalWeight")]
    public double? TotalWeight { get; set; }
    /// <summary>
    /// Indicate shipment origin address information, if it is different from the shipper address.
    /// </summary>
    [JsonProperty("origin")]
    public Origin? Origin { get; set; }
    /// <summary>
    /// Specifies the payment details specifying the method and means of payment to FedEx for providing shipping services.
    /// </summary>

    [JsonProperty("shippingChargesPayment")]
    public ShippingChargesPayment? ShippingChargesPayment { get; set; }
    /// <summary>
    /// Specify the special services requested at the shipment level.
    /// </summary>
    [JsonProperty("shipmentSpecialServices")]
    public ShipmentSpecialServices? ShipmentSpecialServices { get; set; }
    /// <summary>
    /// This is used to provide eMail notification information.
    /// </summary>

    [JsonProperty("emailNotificationDetail")]
    public EmailNotificationDetail? EmailNotificationDetail { get; set; }
    /// <summary>
    ///Indicates the advance booking number, shipper load /count and packing list details. This details must be provided by the user during freight shipment.
    /// </summary>
    [JsonProperty("expressFreightDetail")]
    public ExpressFreightDetail? ExpressFreightDetail { get; set; }
    /// <summary>
    /// Indicate the details about how to calculate variable handling charges at the shipment level. They can be based on a percentage of the shipping charges or a fixed amount. If indicated, element rateLevelType is required.
    /// </summary>
    [JsonProperty("variableHandlingChargeDetail")]
    public VariableHandlingChargeDetail? VariableHandlingChargeDetail { get; set; }
    /// <summary>
    /// These are customs clearance details. Required for International and intra-country Shipments.
    /// </summary>
    [JsonProperty("customsClearanceDetail")]
    public CustomsClearanceDetail? CustomsClearanceDetail { get; set; }
    /// <summary>
    /// Use this object to specify the smartpost shipment details.
    /// </summary>
    [JsonProperty("smartPostInfoDetail")]
    public SmartPostInfoDetail? SmartPostInfoDetail { get; set; }
    /// <summary>
    /// Indicate if the shipment be available to be visible/tracked using FedEx InSight® tool. If value indicated as true, only the shipper/payer will have visibility of this shipment in the FedEx InSight® tool.
    /// </summary>
    [JsonProperty("blockInsightVisibility")]
    public bool? BlockInsightVisibility { get; set; }
    /// <summary>
    /// These are label specification details includes the image type, printer format, and label stock for label. Can also specify specific details such as doc-tab content, regulatory labels, and masking data on the label.
    /// </summary>
    [JsonProperty("labelSpecification")]
    public LabelSpecification? LabelSpecification { get; set; }
    /// <summary>
    /// Use this object to provide all data required for additional (non-label) shipping documents to be produced.
    /// </summary>
    [JsonProperty("shippingDocumentSpecification")]
    public ShippingDocumentSpecification? ShippingDocumentSpecification { get; set; }

    /// <summary>
    /// Indicate the type of rates to be returned.
    /// </summary>
    [JsonProperty("rateRequestType")]
    public List<string?>? RateRequestType { get; set; }
    /// <summary>
    /// Indicate the currency the caller requests to have used in all returned monetary values.
    /// </summary>
    [JsonProperty("preferredCurrency")]
    public string? PreferredCurrency { get; set; }
    /// <summary>
    /// For an MPS, this is the total number of packages in the shipment.Applicable for parent shipment for one label at a time shipments.
    /// </summary>
    [JsonProperty("totalPackageCount")]
    public int? TotalPackageCount { get; set; }
    /// <summary>
    /// Indicates the tracking details of the package.Required for child shipments of an oneLabelAtATime shipments
    /// </summary>
    [JsonProperty("masterTrackingId")]
    public MasterTrackingId? MasterTrackingId { get; set; }
    /// <summary>
    /// These are one or more package-attribute descriptions, each of which describes an individual package, a group of identical packages, or (for the total-piece-total-weight case) common characteristics of all packages in the shipment.
    /// </summary>
    [JsonProperty("requestedPackageLineItems")]
    public List<RequestedPackageLineItem>? RequestedPackageLineItems { get; set; }
}

public class ResponsibleParty
{
    /// <summary>
    ///This is detailed information on physical location. 
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// This is FedEx Account number details.
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }

    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
}

public class ReturnAssociationDetail
{
    /// <summary>
    /// This is the ship date for the outbound shipment associated with a return
    /// </summary>
    [JsonProperty("shipDatestamp")]
    public string? ShipDatestamp { get; set; }
    /// <summary>
    /// This is the tracking number associated with this package.
    /// </summary>
    [JsonProperty("trackingNumber")]
    public string? TrackingNumber { get; set; }
}

public class ReturnEmailDetail
{     /// <summary>
      /// This is the merchant phone number and required for Email Return Labels.
      /// </summary>
    [JsonProperty("merchantPhoneNumber")]
    public string? MerchantPhoneNumber { get; set; }
    /// <summary>
    /// Indicate the allowed (merchant-authorized) special services which may be selected when the subsequent shipment is created.
    ///Only services represented in EmailLabelAllowedSpecialServiceType will be controlled by this list.
    /// </summary>
    [JsonProperty("allowedSpecialService")]
    public List<string?>? AllowedSpecialService { get; set; }
}

public class ReturnInstructionsDetail
{
    /// <summary>
    /// Specify additional information (text) to be inserted into the return document.
    /// </summary>
    [JsonProperty("customText")]
    public string? CustomText { get; set; }
    /// <summary>
    /// These are characteristics of a shipping document to be produced.
    /// </summary>
    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
}

public class ReturnShipmentDetail
{
    /// <summary>
    /// These are email details for the return shipment
    /// </summary>
    [JsonProperty("returnEmailDetail")]
    public ReturnEmailDetail? ReturnEmailDetail { get; set; }
    /// <summary>
    /// This is a Return Merchant Authorization (RMA) for the return shipment.
    ///Reason for the requirement is mandatory.
    /// </summary>
    [JsonProperty("rma")]
    public Rma? Rma { get; set; }
    /// <summary>
    /// Specifies the details of an outbound shipment in order to associate the return shipment to it.
    /// </summary>
    [JsonProperty("returnAssociationDetail")]
    public ReturnAssociationDetail? ReturnAssociationDetail { get; set; }
    /// <summary>
    ///This is the return Type. Required to be set to PRINT_RETURN_LABEL for printed return label shipments.
    /// </summary>
    [JsonProperty("returnType")]
    public string? ReturnType { get; set; }
}

public class Rma
{
    /// <summary>
    /// Specify the reason for the return.
    /// </summary>
    [JsonProperty("reason")]
    public string? Reason { get; set; }
}

public class ShipmentCodAmount
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class ShipmentCODDetail
{
    /// <summary>
    /// Use this object to specify C.O.D. transportation charges.
    /// </summary>
    [JsonProperty("addTransportationChargesDetail")]
    public AddTransportationChargesDetail? AddTransportationChargesDetail { get; set; }
    /// <summary>
    /// Descriptive data of the Cash On Delivery along with their details of the physical location.
    /// </summary>
    [JsonProperty("codRecipient")]
    public CodRecipient? CodRecipient { get; set; }
    /// <summary>
    /// Specify the name of the person or company receiving the secured/unsecured funds payment.
    /// </summary>
    [JsonProperty("remitToName")]
    public string? RemitToName { get; set; }
    /// <summary>
    /// Identifies the type of funds FedEx should collect upon shipment delivery
    /// </summary>
    [JsonProperty("codCollectionType")]
    public string? CodCollectionType { get; set; }
    /// <summary>
    /// Specifies the contact and address details of a location.
    /// </summary>
    [JsonProperty("financialInstitutionContactAndAddress")]
    public FinancialInstitutionContactAndAddress? FinancialInstitutionContactAndAddress { get; set; }
    /// <summary>
    /// Indicate the COD collection amount.
    /// </summary>
    [JsonProperty("codCollectionAmount")]
    public CodCollectionAmount? CodCollectionAmount { get; set; }
    /// <summary>
    /// Indicate return reference type information to include on the COD return shipping label.
    /// </summary>
    [JsonProperty("returnReferenceIndicatorType")]
    public string? ReturnReferenceIndicatorType { get; set; }
    /// <summary>
    /// Indicate the COD amount for this shipment.
    /// </summary>
    [JsonProperty("shipmentCodAmount")]
    public ShipmentCodAmount? ShipmentCodAmount { get; set; }
}

public class ShipmentDryIceDetail
{
    /// <summary>
    /// These are the package weight details.
    /// </summary>
    [JsonProperty("totalWeight")]
    public TotalWeight? TotalWeight { get; set; }
    /// <summary>
    /// Indicates the total number of packages in the shipment that contain dry ice.
    /// </summary>
    [JsonProperty("packageCount")]
    public int? PackageCount { get; set; }
}

public class ShipmentSpecialServices
{
    /// <summary>
    /// Special services requested for the shipment.
    /// </summary>
    [JsonProperty("specialServiceTypes")]
    public List<string?>? SpecialServiceTypes { get; set; }
    /// <summary>
    /// Use this object to specify all information on how the electronic Trade document references used with the shipment.
    /// </summary>
    [JsonProperty("etdDetail")]
    public EtdDetail? EtdDetail { get; set; }
    /// <summary>
    /// Use this object for specifying return shipment details.
    /// </summary>
    [JsonProperty("returnShipmentDetail")]
    public ReturnShipmentDetail? ReturnShipmentDetail { get; set; }
    /// <summary>
    /// Indicate the Delivery On Invoice Acceptance detail. Recipient is required for Delivery On Invoice Special service.
    /// </summary>
    [JsonProperty("deliveryOnInvoiceAcceptanceDetail")]
    public DeliveryOnInvoiceAcceptanceDetail? DeliveryOnInvoiceAcceptanceDetail { get; set; }
    /// <summary>
    /// These are International Traffic In Arms Regulations shipment service details.
    /// </summary>
    [JsonProperty("internationalTrafficInArmsRegulationsDetail")]
    public InternationalTrafficInArmsRegulationsDetail? InternationalTrafficInArmsRegulationsDetail { get; set; }
    /// <summary>
    /// This object is used to specify the Pending Shipment Type for Email label.
    /// </summary>
    [JsonProperty("pendingShipmentDetail")]
    public PendingShipmentDetail? PendingShipmentDetail { get; set; }
    /// <summary>
    /// Use this object to specify required information for a shipment to be held at destination FedEx location.
    /// </summary>
    [JsonProperty("holdAtLocationDetail")]
    public HoldAtLocationDetail? HoldAtLocationDetail { get; set; }
    /// <summary>
    /// This is the shipment level COD detail.
    /// </summary>
    [JsonProperty("shipmentCODDetail")]
    public ShipmentCODDetail? ShipmentCODDetail { get; set; }
    /// <summary>
    /// This is the descriptive data required for a FedEx shipment containing dangerous materials. This element is required when SpecialServiceType DRY_ICE is selected.
    /// </summary>
    [JsonProperty("shipmentDryIceDetail")]
    public ShipmentDryIceDetail? ShipmentDryIceDetail { get; set; }
    /// <summary>
    /// Use this object to specify International Controlled Export shipment Details.
    /// </summary>
    [JsonProperty("internationalControlledExportDetail")]
    public InternationalControlledExportDetail? InternationalControlledExportDetail { get; set; }
    /// <summary>
    /// These are Special service elements for FedEx Ground Home Delivery shipments. If selected, element homedeliveryPremiumType is mandatory.
    /// </summary>
    [JsonProperty("homeDeliveryPremiumDetail")]
    public HomeDeliveryPremiumDetail? HomeDeliveryPremiumDetail { get; set; }
}

public class Shipper
{
    /// <summary>
    /// This is detailed information on physical location. May be used as an actual physical address (place to which one could go), or as a container of address parts which should be handled as a unit (such as a city-state-ZIP combination within the US).
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }

    /// <summary>
    /// This is the tax identification number details.
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
}

public class ShippingChargesPayment
{
    /// <summary>
    /// Specifies the payment Type.
    /// </summary>
    [JsonProperty("paymentType")]
    public string? PaymentType { get; set; }

    /// <summary>
    /// Payor is mandatory when the paymentType is RECIPIENT, THIRD_PARTY or COLLECT.
    /// </summary>
    [JsonProperty("payor")]
    public Payor? Payor { get; set; }
}

public class ShippingDocumentSpecification
{
    /// <summary>
    /// Use this object to specify details to generate general agency agreement detail.
    /// </summary>
    [JsonProperty("generalAgencyAgreementDetail")]
    public GeneralAgencyAgreementDetail? GeneralAgencyAgreementDetail { get; set; }
    /// <summary>
    /// These are return instruction details which will be returned in the transaction to be printed on Return Label.
    /// </summary>
    [JsonProperty("returnInstructionsDetail")]
    public ReturnInstructionsDetail? ReturnInstructionsDetail { get; set; }
    /// <summary>
    /// Use this object to specify details to generate the OP-900 document for hazardous material packages.
    /// </summary>
    [JsonProperty("op900Detail")]
    public Op900Detail? Op900Detail { get; set; }
    /// <summary>
    /// The instructions indicating how to print the USMCA Certificate of Origin (e.g. whether or not to include the instructions, image type, etc ...).
    /// </summary>
    [JsonProperty("usmcaCertificationOfOriginDetail")]
    public UsmcaCertificationOfOriginDetail? UsmcaCertificationOfOriginDetail { get; set; }
    /// <summary>
    /// The instructions indicating commercial invoice certification of origin.
    /// </summary>
    [JsonProperty("usmcaCommercialInvoiceCertificationOfOriginDetail")]
    public UsmcaCommercialInvoiceCertificationOfOriginDetail? UsmcaCommercialInvoiceCertificationOfOriginDetail { get; set; }
    /// <summary>
    /// Indicates the types of shipping documents requested.
    /// </summary>
    [JsonProperty("shippingDocumentTypes")]
    public List<string>? ShippingDocumentTypes { get; set; }
    /// <summary>
    /// The instructions indicating how to print the Certificate of Origin ( e.g. whether or not to include the instructions, image type, etc ...)
    /// </summary>
    [JsonProperty("certificateOfOrigin")]
    public CertificateOfOrigin? CertificateOfOrigin { get; set; }
    /// <summary>
    ///The instructions indicating how to print the Commercial Invoice( e.g. image type) Specifies characteristics of a shipping document to be produced.
    /// </summary>
    [JsonProperty("commercialInvoiceDetail")]
    public CommercialInvoiceDetail? CommercialInvoiceDetail { get; set; }
}

public class SignatureOptionDetail
{
    /// <summary>
    /// This is release number.
    /// </summary>
    [JsonProperty("signatureReleaseNumber")]
    public string? SignatureReleaseNumber { get; set; }
}

public class SmartPostInfoDetail
{
    /// <summary>
    /// Indicate the type of ancillary endorsement. Is required for Presorted Standard but not for returns or parcel select.
    /// </summary>
    [JsonProperty("ancillaryEndorsement")]
    public string? AncillaryEndorsement { get; set; }
    /// <summary>
    /// Specify the four-digit numeric Hub ID value used for smartport shipments.
    /// </summary>
    [JsonProperty("hubId")]
    public string? HubId { get; set; }
    /// <summary>
    /// Specify the indicia type.
    /// </summary>
    [JsonProperty("indicia")]
    public string? Indicia { get; set; }
    /// <summary>
    /// Specify the special handling associated with Smartpost Shipment.
    /// </summary>
    [JsonProperty("specialServices")]
    public string? SpecialServices { get; set; }
}

public class SoldTo
{
    /// <summary>
    /// This is detailed information on physical location.
    /// </summary>
    [JsonProperty("address")]
    public Address? Address { get; set; }
    /// <summary>
    /// Indicate the contact details for this shipment.
    /// </summary>
    [JsonProperty("contact")]
    public Contact? Contact { get; set; }
    /// <summary>
    /// Used for adding the tax id
    /// </summary>
    [JsonProperty("tins")]
    public List<Tin>? Tins { get; set; }
    /// <summary>
    /// This is FedEx Account number details.
    /// </summary>
    [JsonProperty("accountNumber")]
    public AccountNumber? AccountNumber { get; set; }
}

public class Specification
{
    /// <summary>
    /// It is a non-negative integer that represents the portion of doc-tab in a label.
    /// </summary>
    [JsonProperty("zoneNumber")]
    public int? ZoneNumber { get; set; }
    /// <summary>
    /// Indicates the parameter name in the header for the doc tab zone. The maximum charater limit is 7.
    /// </summary>
    [JsonProperty("header")]
    public string? Header { get; set; }
    /// <summary>
    /// Indicate the path request/reply element to be printed on doc tab.
    /// </summary>
    [JsonProperty("dataField")]
    public string? DataField { get; set; }
    /// <summary>
    /// Indicates the actual data to be printed in the label
    /// </summary>
    [JsonProperty("literalValue")]
    public string? LiteralValue { get; set; }
    /// <summary>
    /// Indicates the justification format for the string?.
    /// </summary>
    [JsonProperty("justification")]
    public string? Justification { get; set; }
}

public class TaxesOrMiscellaneousCharge
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class Tin
{
    /// <summary>
    /// Specify tax ID number. Maximum length is 18.
    /// </summary>
    [JsonProperty("number")]
    public string? Number { get; set; }
    /// <summary>
    /// Indicate the type of tax identification number.
    /// </summary>
    [JsonProperty("tinType")]
    public string? TinType { get; set; }
    /// <summary>
    /// Specify the reason for using the tax identification number in shipment processing.
    /// </summary>
    [JsonProperty("usage")]
    public string? Usage { get; set; }
    /// <summary>
    /// Specify the tax ID effective date.
    /// </summary>
    [JsonProperty("effectiveDate")]
    public DateTime? EffectiveDate { get; set; }
    /// <summary>
    /// Specify the tax ID expiration date.
    /// </summary>
    [JsonProperty("expirationDate")]
    public DateTime? ExpirationDate { get; set; }
}

public class TotalCustomsValue
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class TotalDeclaredValue
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class TotalWeight
{
    /// <summary>
    /// This is the package weight unit. For Dry Ice the unit of measure is KG.
    /// </summary>
    [JsonProperty("units")]
    public string? Units { get; set; }
    /// <summary>
    /// Weight Value.
    /// </summary>

    [JsonProperty("value")]
    public int? Value { get; set; }
}

public class UnitPrice
{
    /// <summary>
    /// This is the amount. Maximum limit is 5 digits before decimal.
    /// </summary>
    [JsonProperty("amount")]
    public double? Amount { get; set; }
    /// <summary>
    /// This is the currency code for the amount.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

public class UsmcaCertificationOfOriginDetail
{
    /// <summary>
    /// Specifies the usage and identification of customer supplied images to be used on this document.
    /// </summary>
    [JsonProperty("customerImageUsages")]
    public List<CustomerImageUsage>? CustomerImageUsages { get; set; }
    /// <summary>
    /// Specify the shipping document format.
    /// </summary>
    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
    /// <summary>
    /// This is certifier specification.
    /// </summary>
    [JsonProperty("certifierSpecification")]
    public string? CertifierSpecification { get; set; }
    /// <summary>
    /// This is importer specification.
    /// </summary>
    [JsonProperty("importerSpecification")]
    public string? ImporterSpecification { get; set; }
    /// <summary>
    /// This is producer specification.
    /// </summary>
    [JsonProperty("producerSpecification")]
    public string? ProducerSpecification { get; set; }
    /// <summary>
    /// Object
    /// </summary>
    [JsonProperty("producer")]
    public Producer? Producer { get; set; }
    /// <summary>
    /// Date Range for custom delivery request; only used if type is BETWEEN.
    /// </summary>
    [JsonProperty("blanketPeriod")]
    public BlanketPeriod? BlanketPeriod { get; set; }
    /// <summary>
    /// Specify the job title of the certifier
    /// </summary>
    [JsonProperty("certifierJobTitle")]
    public string? CertifierJobTitle { get; set; }
}

public class UsmcaCommercialInvoiceCertificationOfOriginDetail
{
    /// <summary>
    /// Specifies the usage and identification of customer supplied images to be used on this document.
    /// </summary>
    [JsonProperty("customerImageUsages")]
    public List<CustomerImageUsage>? CustomerImageUsages { get; set; }
    /// <summary>
    /// Specify the shipping document format.
    /// </summary>
    [JsonProperty("documentFormat")]
    public DocumentFormat? DocumentFormat { get; set; }
    /// <summary>
    /// This is certifier specification.
    /// </summary>
    [JsonProperty("certifierSpecification")]
    public string? CertifierSpecification { get; set; }
    /// <summary>
    /// This is importer specification.
    /// </summary>
    [JsonProperty("importerSpecification")]
    public string? ImporterSpecification { get; set; }
    /// <summary>
    /// This is producer specification.
    /// </summary>
    [JsonProperty("producerSpecification")]
    public string? ProducerSpecification { get; set; }
    /// <summary>
    /// OBJECT
    /// </summary>
    [JsonProperty("producer")]
    public Producer? Producer { get; set; }
    /// <summary>
    /// Specify the job title of the certifier
    /// </summary>
    [JsonProperty("certifierJobTitle")]
    public string? CertifierJobTitle { get; set; }
}

public class UsmcaDetail
{
    /// <summary>
    /// Specify the origin criterion.
    /// </summary>
    [JsonProperty("originCriterion")]
    public string? OriginCriterion { get; set; }
}

public class UsmcaLowValueStatementDetail
{
    /// <summary>
    /// Specify the country Of Origin of Low Value Document for Customs declaration.
    /// </summary>
    [JsonProperty("countryOfOriginLowValueDocumentRequested")]
    public bool? CountryOfOriginLowValueDocumentRequested { get; set; }
    /// <summary>
    /// Specify the shipper role for Customs declaration.
    /// </summary>
    [JsonProperty("customsRole")]
    public string? CustomsRole { get; set; }
}

public class VariableHandlingChargeDetail
{
    /// <summary>
    /// The rate type indicates what type of rate request is being returned; account, preferred, incentive, etc.
    /// </summary>
    [JsonProperty("rateType")]
    public string? RateType { get; set; }
    /// <summary>
    /// This is the variable handling percentage. If the percent value is mentioned as 10, it means 10%(multiplier of 0.1).
    /// </summary>
    [JsonProperty("percentValue")]
    public double? PercentValue { get; set; }
    /// <summary>
    /// indicates whether or not the rating is being done at the package level, or if the packages are bundled together. At the package level, charges are applied based on the details of each individual package. If they are bundled, one package is chosen as the parent and charges are applied based on that one package.
    /// </summary>
    [JsonProperty("rateLevelType")]
    public string? RateLevelType { get; set; }
    /// <summary>
    /// This is to specify a fixed handling charge on the shipment. The element allows entry of 7 characters before the decimal and 2 characters following the decimal.
    /// </summary>
    [JsonProperty("fixedValue")]
    public FixedValue? FixedValue { get; set; }
    /// <summary>
    /// Specify the charge type upon which the variable handling percentage amount is calculated.
    /// </summary>
    [JsonProperty("rateElementBasis")]
    public string? RateElementBasis { get; set; }
}

public class Weight
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

public class Zone001
{
    /// <summary>
    /// Indicate the doc tab specification for different zones on the label. The specification includes zone number, header and data field to be displayed on the label.
    /// </summary>
    [JsonProperty("docTabZoneSpecifications")]
    public List<DocTabZoneSpecification>? DocTabZoneSpecifications { get; set; }
}
