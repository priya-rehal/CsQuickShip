using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class QuantityDTO
{
    public string? QuantityType { get; set; }
    public int Amount { get; set; }
    public string? Units { get; set; }
}
