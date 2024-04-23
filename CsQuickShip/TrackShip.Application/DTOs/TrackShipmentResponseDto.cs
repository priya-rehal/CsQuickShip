using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackShip.Application.DTOs;
public class TrackShipmentResponseDto
{
    public string? TransactionId { get; set; }
    public string? CustomerTransactionId { get; set; }
    public Output? Output { get; set; }
}
public class Output
{
    public List<CompleteTrackResult>? CompleteTrackResults { get; set; }
    public string? Alerts { get; set; }
}
public class CompleteTrackResult
{
    public string? TrackingNumber { get; set; }
    public List<TrackResult>? TrackResults { get; set; }
}
public class TrackResult
{
    public TrackingNumberInfos? TrackingNumberInfo { get; set; }
    public AdditionalTrackingInfo? AdditionalTrackingInfo { get; set; }
    public DistanceToDestination? DistanceToDestination { get; set; }
    public List<ConsolidationDetail>? ConsolidationDetail { get; set; }
    public string? MeterNumber { get; set; }
    public ReturnDetail? ReturnDetail { get; set; }
    public ServiceDetail? ServiceDetail { get; set; }
    public DestinationLocation? DestinationLocation { get; set; }
    public LatestStatusDetail? LatestStatusDetail { get; set; }
    public ServiceCommitMessage? ServiceCommitMessage { get; set; }
    public List<InformationNote>? InformationNotes { get; set; }
    public Error? Error { get; set; }
    public List<SpecialHandling>? SpecialHandlings { get; set; }
    public List<AvailableImage>? AvailableImages { get; set; }
    public DeliveryDetails? DeliveryDetails { get; set; }
    public List<ScanEvent>? ScanEvents { get; set; }
    public List<DateAndTime>? DateAndTimes { get; set; }
    public PackageDetails? PackageDetails { get; set; }
    public string? GoodsClassificationCode { get; set; }
    public HoldAtLocation? HoldAtLocation { get; set; }
    public List<CustomDeliveryOption>? CustomDeliveryOptions { get; set; }
    public EstimatedDeliveryTimeWindow? EstimatedDeliveryTimeWindow { get; set; }
    public List<PieceCount>? PieceCounts { get; set; }
    public OriginLocation? OriginLocation { get; set; }
    public RecipientInformation? RecipientInformation { get; set; }
    public StandardTransitTimeWindow? StandardTransitTimeWindow { get; set; }
    public ShipmentDetails? ShipmentDetails { get; set; }
    public ReasonDetail? ReasonDetail { get; set; }
    public List<string>? AvailableNotifications { get; set; }
    public ShipperInformation? ShipperInformation { get; set; }
    public LastUpdatedDestinationAddress? LastUpdatedDestinationAddress { get; set; }
}
public class TrackingNumberInfos
{
    public string? TrackingNumber { get; set; }
    public string? CarrierCode { get; set; }
    public string? TrackingNumberUniqueId { get; set; }
}
public class AdditionalTrackingInfo
{
    public bool HasAssociatedShipments { get; set; }
    public string? Nickname { get; set; }
    public List<PackageIdentifier>? PackageIdentifiers { get; set; }
    public string? ShipmentNotes { get; set; }
}
public class PackageIdentifier
{
    public string? Type { get; set; }
    public string? Value { get; set; }
    public string? TrackingNumberUniqueId { get; set; }
}
public class DistanceToDestination
{
    public string? Units { get; set; }
    public double Value { get; set; }
}
public class ConsolidationDetail
{
    public DateTime TimeStamp { get; set; }
    public string? ConsolidationID { get; set; }
    public ReasonDetail? ReasonDetail { get; set; }
    public int PackageCount { get; set; }
    public string? EventType { get; set; }
}
public class ReasonDetail
{
    public string? Description { get; set; }
    public string? Type { get; set; }
}
public class ReturnDetail
{
    public string? AuthorizationName { get; set; }
    public List<ReasonDetail>? ReasonDetail { get; set; }
}
public class ServiceDetail
{
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public string? Type { get; set; }
}
public class DestinationLocation
{
    public string? LocationId { get; set; }
    public LocationContactAndAddress? LocationContactAndAddress { get; set; }
    public string? LocationType { get; set; }
}
public class LocationContactAndAddress
{
    public Contacts? Contact { get; set; }
    public Address? Address { get; set; }
}
public class Contacts
{
    public string? PersonName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
}
public class Address
{
    public string? AddressClassification { get; set; }
    public bool Residential { get; set; }
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; }
    public string? UrbanizationCode { get; set; }
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
    public string? CountryName { get; set; }
}
public class LatestStatusDetail
{
    public Address? ScanLocation { get; set; }
    public string? Code { get; set; }
    public string? DerivedCode { get; set; }
    public List<AncillaryDetail>? AncillaryDetails { get; set; }
    public string? StatusByLocale { get; set; }
    public string? Description { get; set; }
    public DelayDetail? DelayDetail { get; set; }
}
public class AncillaryDetail
{
    public string? Reason { get; set; }
    public string? ReasonDescription { get; set; }
    public string? Action { get; set; }
    public string? ActionDescription { get; set; }
}
public class DelayDetail
{
    public string? Type { get; set; }
    public string? SubType { get; set; }
    public string? Status { get; set; }
}
public class ServiceCommitMessage
{
    public string? Message { get; set; }
    public string? Type { get; set; }
}
public class InformationNote
{
    public string? Code { get; set; }
    public string? Description { get; set; }
}
public class Error
{
    public string? Code { get; set; }
    public List<Parameter>? ParameterList { get; set; }
    public string? Message { get; set; }
}
public class Parameter
{
    public string? Value { get; set; }
    public string? Key { get; set; }
}
public class SpecialHandling
{
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? PaymentType { get; set; }
}
public class AvailableImage
{
    public string? Size { get; set; }
    public string? Type { get; set; }
}
public class DeliveryDetails
{
    public string? ReceivedByName { get; set; }
    public string? DestinationServiceArea { get; set; }
    public string? DestinationServiceAreaDescription { get; set; }
    public string? LocationDescription { get; set; }
    public Address? ActualDeliveryAddress { get; set; }
    public bool DeliveryToday { get; set; }
    public string? LocationType { get; set; }
    public string? SignedByName { get; set; }
    public string? OfficeOrderDeliveryMethod { get; set; }
    public string? DeliveryAttempts { get; set; }
    public List<DeliveryOptionEligibilityDetail>? DeliveryOptionEligibilityDetails { get; set; }
}
public class DeliveryOptionEligibilityDetail
{
    public string? Option { get; set; }
    public string? Eligibility { get; set; }
}
public class ScanEvent
{
    public DateTime Date { get; set; }
    public string? DerivedStatus { get; set; }
    public Address? ScanLocation { get; set; }
    public string?   LocationId { get; set; }
    public string? LocationType { get; set; }
    public string? ExceptionDescription { get; set; }
    public string? EventDescription { get; set; }
    public string? EventType { get; set; }
    public string? DerivedStatusCode { get; set; }
    public string? ExceptionCode { get; set; }
    public DelayDetail? DelayDetail { get; set; }
}
public class DateAndTime
{
    public DateTime DateTime { get; set; }
    public string? Type { get; set; }
}
public class PackageDetails
{
    public string? PhysicalPackagingType { get; set; }
    public string? SequenceNumber { get; set; }
    public string? UndeliveredCount { get; set; }
    public PackagingDescription? PackagingDescription { get; set; }
    public string? Count { get; set; }
    public WeightAndDimensions? WeightAndDimensions { get; set; }
    public List<string>? PackageContent { get; set; }
    public string? ContentPieceCount { get; set; }
    public DeclaredValue? DeclaredValue { get; set; }
}
public class PackagingDescription
{
    public string? Description { get; set; }
    public string? Type { get; set; }
}
public class WeightAndDimensions
{
    public List<Weight>? Weight { get; set; }
    public List<Dimension>? Dimensions { get; set; }
}
public class Weight
{
    public string? Units { get; set; }
    public double Value { get; set; }
}
public class Dimension
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Units { get; set; }
}
public class DeclaredValue
{
    public string? Currency { get; set; }
    public double Value { get; set; }
}
public class HoldAtLocation
{
    public string? LocationId { get; set; }
    public LocationContactAndAddress? LocationContactAndAddress { get; set; }
    public string? LocationType { get; set; }
}
public class CustomDeliveryOption
{
    public RequestedAppointmentDetail? RequestedAppointmentDetail { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
}
public class RequestedAppointmentDetail
{
    public DateTime Date { get; set; }
    public List<Window>? Window { get; set; }
}
public class Window
{
    public string? Description { get; set; }
    public WindowRange? WindowRange { get; set; }
    public string? Type { get; set; }
}
public class WindowRange    
{
    public DateTime Begins { get; set; }
    public DateTime Ends { get; set; }
}
public class EstimatedDeliveryTimeWindow
{
    public string? Description { get; set; }
    public WindowRange? Window { get; set; }
    public string? Type { get; set; }
}
public class PieceCount
{
    public string? Count { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
}
public class OriginLocation
{
    public string? LocationId { get; set; }
    public LocationContactAndAddress? LocationContactAndAddress { get; set; }
    public string? LocationType { get; set; }
}
public class RecipientInformation
{
    public Contacts? Contact { get; set; }
    public Address? Address { get; set; }
}
public class StandardTransitTimeWindow
{
    public string? Description { get; set; }
    public WindowRange? Window { get; set; }
    public string? Type { get; set; }
}
public class ShipmentDetails
{
    public List<Content>? Contents { get; set; }
    public bool BeforePossessionStatus { get; set; }
    public List<Weight>? Weight { get; set; }
    public string? ContentPieceCount { get; set; }
    public List<SplitShipment>? SplitShipments { get; set; }
}
public class Content
{
    public string? ItemNumber { get; set; }
    public string? ReceivedQuantity { get; set; }
    public string? Description { get; set; }
    public string? PartNumber { get; set; }
}
public class SplitShipment
{
    public string? PieceCount { get; set; }
    public string? StatusDescription { get; set; }
    public DateTime Timestamp { get; set; }
    public string? StatusCode { get; set; }
}
public class ShipperInformation
{
    public Contacts? Contact { get; set; }
    public Address? Address { get; set; }
}
public class LastUpdatedDestinationAddress
{
    public string? AddressClassification { get; set; }
    public bool Residential { get; set; }
    public List<string>? StreetLines { get; set; }
    public string? City { get; set; }
    public string? UrbanizationCode { get; set; }
    public string? StateOrProvinceCode { get; set; }
    public string? PostalCode { get; set; }
    public string? CountryCode { get; set; }
    public string? CountryName { get; set; }
}


