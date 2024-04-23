using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class PhoneNumberDTO
{
    public string? AreaCode { get; set; }
    public string? Extension { get; set; }
    public string? CountryCode { get; set; }
    public string? PersonalIdentificationNumber { get; set; }
    public string? LocalNumber { get; set; }
}

public class PrintedReferenceDTO
{
    public string? PrintedReferenceType { get; set; }
    public string? Value { get; set; }
}

public class ProcessingOptionsDTO
{
    public List<string>? Options { get; set; }
}