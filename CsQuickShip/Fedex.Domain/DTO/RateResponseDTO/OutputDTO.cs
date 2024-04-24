
namespace Fedex.Domain.DTO.RateResponseDTO
{

    public class OutputDTO
    {
        public List<RateReplyDetailDTO>? RateReplyDetails { get; set; }
        public string? QuoteDate { get; set; }
        public bool Encoded { get; set; }
        public List<AlertDTO>? Alerts { get; set; }
    }

    public class PackageRateDetailDTO
    {
        public string? RateType { get; set; }
        public string? RatedWeightMethod { get; set; }
        public double BaseCharge { get; set; }
        public double NetFreight { get; set; }
        public double TotalSurcharges { get; set; }
        public double NetFedExCharge { get; set; }
        public double? TotalTaxes { get; set; }
        public double NetCharge { get; set; }
        public double TotalRebates { get; set; }
        public WeightDTO? BillingWeight { get; set; }
        public decimal? TotalFreightDiscounts { get; set; }
        public List<SurChargeDTO>? Surcharges { get; set; }
        public string? Currency { get; set; }
    }

}