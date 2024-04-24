
namespace Fedex.Domain.DTO.RateResponseDTO
{

    public class RatedShipmentDetailDTO
    {
        public string? RateType { get; set; }
        public string? RatedWeightMethod { get; set; }
        public double TotalDiscounts { get; set; }
        public double TotalBaseCharge { get; set; }
        public double TotalNetCharge { get; set; }
        public double TotalVatCharge { get; set; }
        public double TotalNetFedExCharge { get; set; }
        public double TotalDutiesAndTaxes { get; set; }
        public double TotalNetChargeWithDutiesAndTaxes { get; set; }
        public double TotalDutiesTaxesAndFees { get; set; }
        public double TotalAncillaryFeesAndTaxes { get; set; }
        public ShipmentRateDetailDTO? ShipmentRateDetail { get; set; }
        public string? Currency { get; set; }
        public List<RatedPackageDTO>? RatedPackages { get; set; }

    }

    public class RateReplyDetailDTO
    {
        public string? ServiceType { get; set; }
        public string? ServiceName { get; set; }
        public string? PackagingType { get; set; }
        public List<CustomerMessageDTO>? CustomerMessages { get; set; }
        public List<RatedShipmentDetailDTO>? RatedShipmentDetails { get; set; }
        public bool AnonymouslyAllowable { get; set; }
        public OperationalDetailDTO? OperationalDetail { get; set; }
        public string? SignatureOptionType { get; set; }
        public ServiceDescriptionDTO? ServiceDescription { get; set; }
        public CommitDTO? Commit { get; set; }
    }

    public class ServiceDescriptionDTO
    {
        public string? ServiceId { get; set; }
        public string? ServiceType { get; set; }
        public string? Code { get; set; }
        public List<NameDTO>? Names { get; set; }
        public List<string>? OperatingOrgCodes { get; set; }
        public string? ServiceCategory { get; set; }
        public string? Description { get; set; }
        public string? AstraDescription { get; set; }
       
    }

}