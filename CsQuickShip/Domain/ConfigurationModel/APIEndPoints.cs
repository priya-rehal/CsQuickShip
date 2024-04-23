using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ConfigurationModel;
public class APIEndPoints
{
    public string? BaseURL { get; set; }
    public string? RateQuotesPath { get; set; }
    public string? Comprehensiverates { get; set; }
}
