using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class InternationalControlledExportDetailDTO
{
    public string? Type { get; set; }
}

public class InternationalTrafficInArmsRegulationsDetailDTO
{
    public string? LicenseOrExemptionNumber { get; set; }
}
public class InnerReceptacleDTO
{
    public QuantityDTO? Quantity { get; set; }
}
