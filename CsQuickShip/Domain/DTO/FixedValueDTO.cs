using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class FixedValueDTO
{
    public string? Amount { get; set; }
    public string? Currency { get; set; }
}
public class FinancialInstitutionContactAndAddressDTO
{
    public AddressDTO? Address { get; set; }
    public ContactDTO? Contact { get; set; }
}
