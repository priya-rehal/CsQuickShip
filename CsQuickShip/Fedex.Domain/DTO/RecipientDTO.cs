
using System.Text.Json.Serialization;

namespace Fedex.Domain.DTO;
public class RecipientDTO
{
    public AddressDTO? Address { get; set; }
    public AccountNumberDTO? AccountNumber { get; set; }
    public ContactDTO? Contact { get; set; }
}
// for emailNotificationDetail

public class RecipientsDTO
{
    public string? EmailAddress { get; set; }
    public List<string>? NotificationEventType { get; set; }
    public SmsDetailDTO? SmsDetail { get; set; }
    public string? notificationFormatType { get; set; }
    public string? emailNotificationRecipientType { get; set; }
    public string? notificationType { get; set; }
    public string? locale { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OptionsRequestedDTO? OptionsRequested { get; set; }
    public string? Role { get; set; }
}

public class RecommendedDocumentSpecificationDTO
{
    public List<string>? Types { get; set; }
}

public class RequestedPackageLineItemDTO
{
    public string? SubPackagingType { get; set; }
    public int GroupPackageCount { get; set; }
    public List<ContentRecordDTO>? ContentRecord { get; set; }
    public DeclaredValueDTO? DeclaredValue { get; set; }
    public WeightDTO? Weight { get; set; }
    public DimensionsDTO? Dimensions { get; set; }
    public VariableHandlingChargeDetailDTO? VariableHandlingChargeDetail { get; set; }
    public PackageSpecialServicesDTO? PackageSpecialServices { get; set; }
}