using Newtonsoft.Json;
using System.Collections.Generic;
namespace Domain.DTO.RateResponseDTO
{
    //Dell this one
    public class RatedPackageDTO
    {
        public int GroupNumber { get; set; }
        public double? EffectiveNetDiscount { get; set; }
        public PackageRateDetailDTO? PackageRateDetail { get; set; }
        
    }

}