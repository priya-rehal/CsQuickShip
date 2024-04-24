
namespace Fedex.Domain.DTO;
public class RequestedShipmentDTO
{
    public ShipperDTO? Shipper { get; set; }
    public RecipientDTO? Recipient { get; set; } //Problem here
    public string? serviceType { get; set; }
    public EmailNotificationDetailDTO? EmailNotificationDetail { get; set; }
    public string? PreferredCurrency { get; set; }
    public List<string> RateRequestType { get; set; } = new List<string> { "LIST", "ACCOUNT" };
    public string? ShipDateStamp { get; set; }
    public string? PickupType { get; set; }
    public List<RequestedPackageLineItemDTO>? RequestedPackageLineItems { get; set; }
    public bool? DocumentShipment { get; set; }
    public VariableHandlingChargeDetailDTO? VariableHandlingChargeDetail { get; set; }
    public string? PackagingType { get; set; }
    public int TotalPackageCount { get; set; }
    public double TotalWeight { get; set; }
    public ShipmentSpecialServicesDTO? ShipmentSpecialServices { get; set; }
    public CustomsClearanceDetailDTO? CustomsClearanceDetail { get; set; }
    public bool GroupShipment { get; set; }
    public ServiceTypeDetailDTO? ServiceTypeDetail { get; set; }
    public SmartPostInfoDetailDTO? SmartPostInfoDetail { get; set; }
    public ExpressFreightDetailDTO? ExpressFreightDetail { get; set; }
    public bool GroundShipment { get; set; }
}

public class ResponsiblePartyDTO
{
    public AddressDTO? Address { get; set; }
    public ContactDTO? Contact { get; set; }
    public AccountNumberDTO? AccountNumber { get; set; }
}

public class ReturnShipmentDetailDTO
{
    public string? ReturnType { get; set; } 
}
