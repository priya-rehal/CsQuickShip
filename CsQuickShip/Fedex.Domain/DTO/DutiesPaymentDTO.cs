
namespace Fedex.Domain.DTO;
public class DutiesPaymentDTO
{
    public PayorDTO? Payor { get; set; }
    public string? PaymentType { get; set; }
}

public class DryIceWeightDTO
{
    public string? Units { get; set; }
    public int Value { get; set; }
}

public class DocumentReferenceDTO
{
    public string? DocumentType { get; set; }
    public string? CustomerReference { get; set; }
    public string? Description { get; set; }
    public string? DocumentId { get; set; }
}

public class DimensionsDTO
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? Units { get; set; }
}

public class DescriptionDTO
{
    public int SequenceNumber { get; set; }
    public List<string>? ProcessingOptions { get; set; }
    public string? SubsidiaryClasses { get; set; }
    public string? LabelText { get; set; }
    public string? TechnicalName { get; set; }
    public PackingDetailsDTO? PackingDetails { get; set; }
    public string? Authorization { get; set; }
    public bool ReportableQuantity { get; set; }
    public int Percentage { get; set; }
    public string? Id { get; set; }
    public string? PackingGroup { get; set; }
    public string? ProperShippingName { get; set; }
    public string? HazardClass { get; set; }
}

public class DeliveryOnInvoiceAcceptanceDetailDTO
{
    public RecipientDTO? Recipient { get; set; }
}

public class DeclaredValueDTO
{
    public string? Amount { get; set; }
    public string? Currency { get; set; }
}

public class DangerousGoodsDetailDTO
{
    public string? Offeror { get; set; }
    public string? Accessibility { get; set; }
    public string? EmergencyContactNumber { get; set; }
    public List<string> Options { get; set; }
    public List<ContainerDTO>? Containers { get; set; }
    public PackagingDTO? Packaging { get; set; }
}
