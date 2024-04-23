    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.DTOs;
public class RegisterCredentialResponse
{
    public string? TransactionId { get; set; }
    public Output? output { get; set; }

    public class Output
    {
        public string? CustomerKey { get; set; }
        public string? CustomerPassword { get; set; }
        public List<Alert>? Alerts { get; set; }

        public class Alert
        {
            public string? Code { get; set; }
            public string? AlertType { get; set; }
            public List<Parameter> ParameterList { get; set; }
            public string? Message { get; set; }

            public class Parameter
            {
                public string? Value { get; set; }
                public string? Key { get; set; }
            }
        }
    }
}
