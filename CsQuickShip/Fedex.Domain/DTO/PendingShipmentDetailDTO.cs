

namespace Fedex.Domain.DTO;
public class PendingShipmentDetailDTO
{
    public string? PendingShipmentType { get; set; }
    public ProcessingOptionsDTO? ProcessingOptions { get; set; }
    public RecommendedDocumentSpecificationDTO? RecommendedDocumentSpecification { get; set; }
    public EmailLabelDetailDTO? EmailLabelDetail { get; set; }
    public List<DocumentReferenceDTO>? documentReferences { get; set; }
    public string? ExpirationTimeStamp { get; set; }
    public ShipmentDryIceDetailDTO? ShipmentDryIceDetail { get; set; }
}
public class PayorDTO
{
    public ResponsiblePartyDTO? ResponsibleParty { get; set; }
}


