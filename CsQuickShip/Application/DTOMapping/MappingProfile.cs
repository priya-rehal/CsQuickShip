using AutoMapper;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOMapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
    //    CreateMap<RateQuoteRequestDTO, RateRequestDTO>()
    //        .ForMember(dest => dest.AccountNumber, option => option.MapFrom(x => x.AccountNumber))
    //.ForPath(dest => dest.RequestedShipment.Shipper.Address, option => option.MapFrom(x => x.ToAddress))
    //.ForPath(dest => dest.RequestedShipment.Recipient.Address, option => option.MapFrom(x => x.FromAddress))
    //.ForPath(dest => dest.RequestedShipment.PackagingType, option => option.MapFrom(x => x.PackagingType))
    //.ForPath(dest => dest.RequestedShipment.ShipmentSpecialServices.SpecialServiceTypes, option =>
    //                 option.MapFrom(x => x.ShipmentSpecialServices))
    //.ForPath(dest => dest.RequestedShipment.PackagingType, option => option.MapFrom(x => x.PackagingType))
    //.ForPath(dest => dest.RequestedShipment.ShipmentSpecialServices.SpecialServiceTypes, option =>
    //                 option.MapFrom(x => x.ShipmentSpecialServices));

    //    CreateMap<RateQuoteRequestDTO, RequestedPackageLineItemDTO>()
    //.ForMember(dest => dest.Weight, option => option.MapFrom(src => src.RequestedPackageLineItems.FirstOrDefault().Weight))
    //.ForMember(dest => dest.PackageSpecialServices.SpecialServiceTypes,
    //         option => option.MapFrom(src => src.RequestedPackageLineItems.FirstOrDefault().SpecialServiceTypes));

    //    CreateMap<RequestPKGLineItemsDTO, RequestedPackageLineItemDTO>().ReverseMap();

    }
}


