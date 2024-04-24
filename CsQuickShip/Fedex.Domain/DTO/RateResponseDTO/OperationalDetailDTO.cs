
namespace Fedex.Domain.DTO.RateResponseDTO
{

    public class OperationalDetailDTO
    {
        public string? OriginLocationIds { get; set; }
        public string? CommitDays { get; set; }
        public string? ServiceCode { get; set; }
        public string? AirportId { get; set; }
        public string? Scac { get; set; }
        public string? OriginServiceAreas { get; set; }
        public string? DeliveryDay { get; set; }
        public int OriginLocationNumbers { get; set; }
        public string? DestinationPostalCode { get; set; }
        public DateTime CommitDate { get; set; }
        public string? AstraDescription { get; set; }
        public string? DeliveryDate { get; set; }
        public string? DeliveryEligibilities { get; set; }
        public bool IneligibleForMoneyBackGuarantee { get; set; }
        public string? MaximumTransitTime { get; set; }
        public string? AstraPlannedServiceLevel { get; set; }
        public string? DestinationLocationIds { get; set; }
        public string? DestinationLocationStateOrProvinceCodes { get; set; }
        public string? TransitTime { get; set; }
        public string? PackagingCode { get; set; }
        public int DestinationLocationNumbers { get; set; }
        public string? PublishedDeliveryTime { get; set; }
        public string? CountryCodes { get; set; }
        public string? StateOrProvinceCodes { get; set; }
        public string? UrsaPrefixCode { get; set; }
        public string? UrsaSuffixCode { get; set; }
        public string? DestinationServiceAreas { get; set; }
        public string? OriginPostalCodes { get; set; }
        public string? CustomTransitTime { get; set; }
    }

}