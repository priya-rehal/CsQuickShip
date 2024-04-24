

namespace Fedex.Domain.DTO;
public class PackageSpecialServicesDTO
{
    public List<string>? SpecialServiceTypes { get; set; }
    //For testing purpose disabled that
    //public List<string>? SignatureOptionType { get; set; }
     public string? SignatureOptionType { get; set; }
    public AlcoholDetailDTO? AlcoholDetail { get; set; }
    public DangerousGoodsDetailDTO? DangerousGoodsDetail { get; set; }
    public PackageCODDetailDTO? PackageCODDetail { get; set; }
    public int PieceCountVerificationBoxCount { get; set; }
    public List<BatteryDetailDTO>? BatteryDetails { get; set; }
    public DryIceWeightDTO? DryIceWeight { get; set; }
}

public class PackagingDTO
{
    public int Count { get; set; }
    public string? Units { get; set; }
}

public class PackingDetailsDTO
{
    public string? PackingInstructions { get; set; }
    public bool CargoAircraftOnly { get; set; }
}

public class PackageCODDetailDTO
{
    public CodCollectionAmountDTO? CodCollectionAmount { get; set; }
    public string? CodCollectionType { get; set; }
}
