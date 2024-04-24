using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class EmailLabelDetailDTO
{
    public List<RecipientsDTO>? Recipients { get; set; }
    public string? Message { get; set; }
}

public class EmailNotificationDetailDTO
{
    public List<RecipientsDTO>? Recipients { get; set; }
    public string? PersonalMessage { get; set; }
    public PrintedReferenceDTO? PrintedReference { get; set; }
}
