
using Fedex.Application.ClientFactory;
using Fedex.Domain.ConfigurationModel;
using Fedex.Domain.DTO;
using Fedex.Domain.DTO.RateResponseDTO;
using MediatR;
using Microsoft.Extensions.Options;

namespace Fedex.Application.CQRS.Commands;
public class RatesCommand:IRequest<RateResponseDTO> 
{
    public readonly RateRequestDTO _rateRequest;
    

    public RatesCommand(RateRequestDTO rateRequest) 
        => (_rateRequest) = (rateRequest);

}

//Request handler of RatesCommand
internal class RatesCommandHandler : IRequestHandler<RatesCommand, RateResponseDTO> 
{
    private readonly IBaseClientFactory<RateRequestDTO, RateResponseDTO> _clientFactory;
    private readonly APIEndPoints _endPoints;
   

    public RatesCommandHandler(
        IBaseClientFactory<RateRequestDTO, RateResponseDTO> baseClientFactory,
        IOptions<APIEndPoints> options
        ) => ( _clientFactory, _endPoints) = (baseClientFactory, options.Value);


    public async Task<RateResponseDTO> Handle(RatesCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        try
        {
            //var parsedata = request._rateRequest.CarrierType switch
            //{
            //    CarrierType.FEDEX => DTOParseHelper.ParseFedexRate(request._rateRequest),
            //    CarrierType.DHL => throw new NotImplementedException(),
            //    _=> throw new NotImplementedException()
            //};
            RateResponseDTO response = await _clientFactory.SendAsync(
                                    _endPoints.Comprehensiverates, request._rateRequest,
                                     HttpMethod.Post, cancellationToken);

            return response != null ? response : new RateResponseDTO();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
        return null;
    }

  


    //private RateRequestDTO ParseFedeXRate(RateQuoteRequestDTO rateQuoteRequest)
    //{
    //    return 
    //}
}




