using AutoMapper;
using GapInsurance.Data;
using GapInsurance.Models;
using System;

namespace GapInsurance.Service
{
    public static class GapMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Clients, ClientsDto>();
                cfg.CreateMap<Coverages, CoveragesDto>()
                    .ForSourceMember(x => x.Policies, opt => opt.Ignore());
                cfg.CreateMap<CoveragesDto, Coverages>()
                    .ForMember(x => x.Policies, opt => opt.Ignore());

                cfg.CreateMap<Customers, CustomersDto>();
                cfg.CreateMap<Policies, PoliciesDto>();
                cfg.CreateMap<Customer_Policies, Customer_PoliciesDto>()
                        .ForMember(destination => destination.RiskType,
                                 opt => opt.MapFrom(source => Enum.GetName(typeof(RiskType), source.RiskType))); ;

                
                    

                cfg.CreateMap<RiskType, string>().ConvertUsing(src => src.ToString());

            });
        }
    }
}