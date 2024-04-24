using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class CustomsValueDTO
{
    public int Amount { get; set; }
    public string? Currency { get; set; }
}

public class CustomsClearanceDetailDTO
{
    public List<BrokersDTO>? Brokers { get; set; }
    public CommercialInvoiceDTO? CommercialInvoice { get; set; }
    public string? FreightOnValue { get; set; }
    public DutiesPaymentDTO? DutiesPayment { get; set; }
    public List<CommodityDTO>? Commodities { get; set; }
}

public class ContentRecordDTO
{
    public string? ItemNumber { get; set; }
    public int ReceivedQuantity { get; set; }
    public string? Description { get; set; }
    public string? PartNumber { get; set; }
}

public class ContainerDTO
{
    public string? Offeror { get; set; }
    public List<HazardousCommodityDTO> HazardousCommodities { get; set; }
    public int NumberOfContainers { get; set; }
    public string? ContainerType { get; set; }
    public EmergencyContactNumberDTO? EmergencyContactNumber { get; set; }
    public PackagingDTO? Packaging { get; set; }
    public string? PackingType { get; set; }
    public string? RadioactiveContainerClass { get; set; }
}

public class ContactDTO
{
    public string? PersonName { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneExtension { get; set; }
    public string? CompanyName { get; set; }
    public string? FaxNumber { get; set; }
}

public class CommodityDTO
{
    public string? Description { get; set; }
    public WeightDTO? Weight { get; set; }
    public int Quantity { get; set; }
    public CustomsValueDTO? CustomsValue { get; set; }
    public UnitPriceDTO? UnitPrice { get; set; }
    public int NumberOfPieces { get; set; }
    public string? CountryOfManufacture { get; set; }
    public string? QuantityUnits { get; set; }
    public string? Name { get; set; }
    public string? HarmonizedCode { get; set; }
    public string? PartNumber { get; set; }
}

public class CommercialInvoiceDTO
{
    public string? ShipmentPurpose { get; set; }
}

public class CodCollectionAmountDTO
{
    public double? Amount { get; set; }
    public string? Currency { get; set; }
}

public class CodRecipientDTO
{
    public AccountNumberDTO? AccountNumber { get; set; }
}
