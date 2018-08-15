using AulaWeb.Dto;
using AulaWeb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movies, MoviesDto>();
            
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.id, opt => opt.Ignore());

            Mapper.CreateMap<MoviesDto, Movies>()
               .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}