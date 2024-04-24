

namespace Fedex.Domain.DTO;
public class OptionsDTO
{
    public string? LabelTextOption { get; set; }
    public string? CustomerSuppliedLabelText { get; set; }
}
public class OptionsRequestedDTO
{
    public List<string>? Options { get; set; }
}