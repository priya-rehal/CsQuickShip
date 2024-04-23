using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.DTOs;
public class RegisterCredentialsRequestDto
{
 
    
        public Address? Address { get; set; }
        public string? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
        public Carrier? Carrier { get; set; }
}

    public class Address
    {
        public bool Residential { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }
        public string? PostalCode { get; set; }
        public string[]? StreetLines { get; set; }
        public string? StateOrProvinceCode { get; set; }
    }
public enum Carrier
{
    Fedex,
    Amazon
}