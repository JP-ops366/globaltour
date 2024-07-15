using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entitys;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Place, PlaceDTO>()
                .ForMember(d=>d.country, o=>o.MapFrom(s=>s.country.Name))
                .ForMember(d=>d.category, o=>o.MapFrom(s=>s.category.Name))
                .ForMember(d=>d.ImageUrl, o=>o.MapFrom<PlaceUrlResolver>());
        }
    }
}