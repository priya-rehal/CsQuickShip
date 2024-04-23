using Label.Application.DTOs.CsQuickShipDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label.Application.DTOs.LabelDTOs;
public class FedexPackageLevelCustomeResponse
{
    public Address? Shipper { get; set; }
    public List<Address>? Recipients { get; set; }
    public List<PackageList>? Packages { get; set; }
}
public class PackageList
{
    public string? TrackingNumber { get; set; }
    public string? EncodedLabel { get; set; }
}