using Domain.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Domain.DTO.RateResponseDTO
{
    public class ShipmentRateDetailDTO
    {
        public string? RateZone { get; set; }
        public double DimDivisor { get; set; }
        public double FuelSurchargePercent { get; set; }
        public double TotalSurcharges { get; set; }
        public decimal? TotalFreightDiscount { get; set; }
        public List<SurChargeDTO>? SurCharges { get; set; }
        public string? PricingCode { get; set; }
        public WeightDTO? TotalBillingWeight { get; set; }
        public CurrencyExchangeRateDTO? CurrencyExchangeRate { get; set; }
        public string? Currency { get; set; }
    }

    

}