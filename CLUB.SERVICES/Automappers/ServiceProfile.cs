using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using CLUB.CONTEXT.CONTRACTS.Enums;
using CLUB.SERVICES.CONTRACTS.Models;

namespace CLUB.SERVICES.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<GradeTypes, CONTRACTS.Enums.GradeTypes>()
               .ConvertUsingEnumMapping(opt => opt.MapByName())
            .ReverseMap();

            CreateMap<CONTEXT.CONTRACTS.Models.Client, Client>(MemberList.Destination);

            CreateMap<CONTEXT.CONTRACTS.Models.FreeMen, FreeMen>(MemberList.Destination);

            CreateMap<CONTEXT.CONTRACTS.Models.Order, Order>(MemberList.Destination)
                .ForMember(opt => opt.FreeMen, next => next.MapFrom(x=>x.FreeMenId))
                .ForMember(opt => opt.Client, next => next.MapFrom(x => x.ClientId))
                .ForMember(opt => opt.Service, next => next.MapFrom(x => x.ServiceId))
                .ForMember(opt => opt.WherePay, next => next.MapFrom(x => x.PayId))
                .ForMember(opt => opt.WherePlace, next => next.MapFrom(x => x.PlaceId));

            CreateMap<CONTEXT.CONTRACTS.Models.Service, ServiceModel>(MemberList.Destination);

            CreateMap<CONTEXT.CONTRACTS.Models.WherePay, WherePayModel>(MemberList.Destination);

            CreateMap<CONTEXT.CONTRACTS.Models.WherePlace, WherePlaceModel>(MemberList.Destination);

        }
    }
}
