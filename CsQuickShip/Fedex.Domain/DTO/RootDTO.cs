namespace Fedex.Domain.DTO;
public class RootDTO
{
    public AccountNumberDTO? AccountNumber { get; set; }
    public RateRequestControlParametersDTO? RateRequestControlParameters { get; set; }
    public RequestedShipmentDTO? RequestedShipment { get; set; }
    public List<string>? CarrierCodes { get; set; }
}


