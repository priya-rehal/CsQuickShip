namespace Fedex.Domain.DTO.RateResponseDTO
{

    public class AlertDTO
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? AlertType { get; set; }
    }

    public class CustomerMessageDTO
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }

}