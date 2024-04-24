using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class HomeDeliveryPremiumDetailDTO
{
    public PhoneNumberDTO? PhoneNumber { get; set; }
    public string? ShipTimestamp { get; set; }
    public string? HomedeliveryPremiumType { get; set; }
}

public class HoldAtLocationDetailDTO
{
    public string? LocationId { get; set; }
    public LocationContactAndAddressDTO? LocationContactAndAddress { get; set; }
    public string? LocationType { get; set; }
}

public class HazardousCommodityDTO
{
    public QuantityDTO? Quantity { get; set; }
    public List<InnerReceptacleDTO?> InnerReceptacles { get; set; }
    public OptionsDTO? Options { get; set; }
    public DescriptionDTO? Description { get; set; }
}
