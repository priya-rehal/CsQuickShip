
namespace Fedex.Domain.DTO;
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
