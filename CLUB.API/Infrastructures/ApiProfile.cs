using CLUB.API.Enums;
using CLUB.API.Models;
using CLUB.API.ModelsRequest;
using CLUB.SERVICES.CONTRACTS.Enums;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using CLUB.SERVICES.CONTRACTS.Models;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Microsoft.OpenApi.Extensions;
using CLUB.CONTEXT.CONTRACTS.Models;

namespace CLUB.API.Infrastructures
{
    /// <summary>
    /// Профиль маппера Api
    /// </summary>
    public class ApiProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiProfile"/>
        /// </summary>
        public ApiProfile()
        {
            CreateMap<SERVICES.CONTRACTS.Enums.GradeTypes, Enums.GradeTypes>()
               .ConvertUsingEnumMapping(opt => opt.MapByName())
               .ReverseMap();

            CreateMap<SERVICES.CONTRACTS.Models.Client, ClientResp>(MemberList.Destination);
            CreateMap<ClientReqCreate, ClientReq>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ClientReqEdit, ClientReq>(MemberList.Destination);

            CreateMap<SERVICES.CONTRACTS.Models.FreeMen, FreeMenResp>(MemberList.Destination);
            CreateMap<FreeMenReqCreate, FreeMenReq>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<FreeMenReqEdit, FreeMenReq>(MemberList.Destination);


            CreateMap<ServiceModel, ServiceResp>(MemberList.Destination);
            CreateMap<ServiceReqCreate, ServiceModelReq>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ServiceReqEdit, ServiceModelReq>(MemberList.Destination);
            CreateMap<WherePayModel, WherePayResp>(MemberList.Destination);
            CreateMap<WherePayReqCreate, WherePayModelReq>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<WherePayReqEdit, WherePayModelReq>(MemberList.Destination);
            CreateMap<WherePlaceModel, WherePlaceResp>(MemberList.Destination);
            CreateMap<WherePlaceReqCreate, WherePlaceModelReq>(MemberList.Destination)
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<WherePlaceReqEdit, WherePlaceModelReq>(MemberList.Destination);

            CreateMap<SERVICES.CONTRACTS.Models.Order, OrderResp>(MemberList.Destination)
                .ForMember(opt => opt.FreeMen, next => next.MapFrom(x=> x.FreeMen))
                .ForMember(opt => opt.Client, next => next.MapFrom(x => x.Client))
                .ForMember(opt => opt.Service, next => next.MapFrom(x => x.Service))
                .ForMember(opt => opt.WherePay, next => next.MapFrom(x => x.WherePay))
                .ForMember(opt => opt.WherePlace, next => next.MapFrom(x => x.WherePlace));
            CreateMap<OrderReqCreate, OrderReq>(MemberList.Destination)
                .ForMember(opt => opt.FreeMenId, next => next.MapFrom(x => x.FreeMen))
                .ForMember(opt => opt.ClientId, next => next.MapFrom(x => x.Client))
                .ForMember(opt => opt.ServiceId, next => next.MapFrom(x => x.Service))
                .ForMember(opt => opt.PayId, next => next.MapFrom(x => x.WherePay))
                .ForMember(opt => opt.PlaceId, next => next.MapFrom(x => x.WherePlace))
                 .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<OrderReqEdit, OrderReq>(MemberList.Destination)
                .ForMember(opt => opt.FreeMenId, next => next.MapFrom(x => x.FreeMen))
                .ForMember(opt => opt.ClientId, next => next.MapFrom(x => x.Client))
                .ForMember(opt => opt.ServiceId, next => next.MapFrom(x => x.Service))
                .ForMember(opt => opt.PayId, next => next.MapFrom(x => x.WherePay))
                .ForMember(opt => opt.PlaceId, next => next.MapFrom(x => x.WherePlace));


        }
    }
}
