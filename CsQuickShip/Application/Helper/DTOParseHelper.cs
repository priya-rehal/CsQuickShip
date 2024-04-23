using AutoMapper.Internal;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helper;
public static class DTOParseHelper
{
    public static RateRequestDTO ParseFedexRate(RateQuoteRequestDTO rateQuote)
    {
        return new RateRequestDTO
        {
            AccountNumber = rateQuote.AccountNumber,
            RequestedShipment = new RequestedShipmentDTO
            {
                Shipper = new ShipperDTO
                {
                    Address = rateQuote.FromAddress
                },

                Recipient = new RecipientDTO
                {
                    Address = rateQuote.ToAddress
                },
                ShipmentSpecialServices = rateQuote.ShipmentSpecialServices,
               
                RequestedPackageLineItems = rateQuote.RequestedPackageLineItems.Select(x => new RequestedPackageLineItemDTO
                {
                    GroupPackageCount = x.GroupPackageCount,
                    Weight = x.Weight,
                    PackageSpecialServices = x.PackageSpecialServices
                    
                }).ToList(),
                ShipDateStamp = rateQuote.ShipDateStamp,
                PackagingType = rateQuote?.PackagingType,
                serviceType = rateQuote?.ServiceType,
                PickupType = rateQuote?.PickupType, 
            },
        };
    }
    public static RateRequestDTO ParseDHLRate(RateQuoteRequestDTO rateQuote) { return null; }
}
