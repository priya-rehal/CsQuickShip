using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class OptionsDTO
{
    public string? LabelTextOption { get; set; }
    public string? CustomerSuppliedLabelText { get; set; }
}
public class OptionsRequestedDTO
{
    public List<string>? Options { get; set; }
}