using Domain.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.RateResponseDTO;
public class RateResponseDTO: IRateResponse
{
    public string? TransactionId { get; set; }
    public string? CustomerTransactionId { get; set; }
    public OutputDTO? Output { get; set; }
}
