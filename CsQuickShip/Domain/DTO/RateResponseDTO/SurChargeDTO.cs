using Newtonsoft.Json;

namespace Domain.DTO.RateResponseDTO
{

    public class SurChargeDTO
    {
        public string? Type { get; set; }
        public string? Description { get; set; }
        public double? Amount { get; set; }
       /* public string? Level { get; set; }*/  //Some casees lavel where not need
    }

    //Rate Response Root
    public class Root
    {
        public string? TransactionId { get; set; }
        public string? CustomerTransactionId { get; set; }
        public OutputDTO? Output { get; set; }
    }
}