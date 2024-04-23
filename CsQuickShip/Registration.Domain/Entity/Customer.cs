using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Entity;
public class Customer
{
    [Key]
    public string? AccountNumber { get; set; }
    public string? CustomerName { get; set; }
    public bool Residential { get; set; }
    public string? City { get; set; }
    public string? CountryCode { get; set; }
    public string? PostalCode { get; set; }
    public List<string>? StreetLines { get; set; }
    public string? StateOrProvinceCode { get; set; }
}
