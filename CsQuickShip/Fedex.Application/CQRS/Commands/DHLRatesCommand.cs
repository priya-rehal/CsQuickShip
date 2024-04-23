
namespace Fedex.Application.CQRS.Commands;
public class DHLRatesCommand
{
    private readonly Object _object;
    public DHLRatesCommand(object value)
    {
           _object = value;
    }
}
