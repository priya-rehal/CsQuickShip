using Newtonsoft.Json;

namespace Domain.DTO.RateResponseDTO
{

    public class CurrencyExchangeRateDTO
    {
        public string? FromCurrency { get; set; }
        public string? IntoCurrency { get; set; }
        public double? Rate { get; set; }
    }

    public class DateDetailDTO
    {
        public string? DayOfWeek { get; set; }
        public DateTime DayCxsFormat { get; set; }
    }

    public class NameDTO
    {
        public string? Type { get; set; }
        public string? Encoding { get; set; }
        public string? Value { get; set; }
    }
}