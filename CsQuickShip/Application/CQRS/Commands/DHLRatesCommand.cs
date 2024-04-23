using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands;
public class DHLRatesCommand
{
    private readonly Object _object;
    public DHLRatesCommand(object value)
    {
           _object = value;
    }
}
