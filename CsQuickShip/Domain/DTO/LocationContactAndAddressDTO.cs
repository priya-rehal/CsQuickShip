using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class LocationContactAndAddressDTO
{
    public AddressDTO? Address { get; set; }
    public ContactDTO? Contact { get; set; }
}
