using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackShip.Application.DTOs;
public class TrackShipmentRequestDto
{
    [JsonProperty("trackingInfo")]
    public List<TrackingInfo>? TrackingInfo { get; set; }

    [JsonProperty("includeDetailedScans")]
    public bool? IncludeDetailedScans { get; set; }
}

public class TrackingInfo
{
    [JsonProperty("trackingNumberInfo")]
    public TrackingNumberInfo? TrackingNumberInfo { get; set; }
}

public class TrackingNumberInfo
{
    [JsonProperty("trackingNumber")]
    public string? TrackingNumber { get; set; }
}
