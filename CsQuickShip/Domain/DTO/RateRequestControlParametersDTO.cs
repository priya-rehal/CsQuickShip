using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.DTO;
public class RateRequestControlParametersDTO
{
    public bool? ReturnTransitTimes { get; set; }
    public bool? ServicesNeededOnRateFailure { get; set; }
    public string? VariableOptions { get; set; }
    public string? RateSortOrder { get; set; }
}


public class RateRequestDTO 
{
    public AccountNumberDTO? AccountNumber { get; set; }
    public RateRequestControlParametersDTO? RateRequestControlParameters {  get; set; }
    public RequestedShipmentDTO? RequestedShipment { get; set; }
    public List<string>? CarrierCodes { get; set; }
}

public class RateQuoteRequestDTO
{
    public AccountNumberDTO? AccountNumber { get; set; }
    public AddressDTO? FromAddress { get; set; }
    public AddressDTO? ToAddress { get; set; }
    public string? ServiceType { get; set; }
    public CarrierType CarrierType { get; set; }
    public string? PackagingType { get; set; }
    public string? PickupType { get; set; }
    public ShipmentSpecialServicesDTO? ShipmentSpecialServices { get; set; }
    public List<RequestPKGLineItemsDTO>? RequestedPackageLineItems { get; set; }
    public string? ShipDateStamp { get; set; }

}
 


public enum CarrierType
{
    FEDEX,
    DHL,
    AMAZONE,
    SHIPPOST
}

public class RequestPKGLineItemsDTO
{
    public int GroupPackageCount { get; set; }
    public WeightDTO? Weight { get; set; }
    public PackageSpecialServicesDTO? PackageSpecialServices { get; set; }
}













