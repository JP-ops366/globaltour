using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entitys;

namespace API.Helpers
{
    public class PlaceUrlResolver : IValueResolver<Place, PlaceDTO, string>
    {
        public IConfiguration _configuration { get; set; }
        public PlaceUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string Resolve(Place source, PlaceDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _configuration["ApiUrl"]+source.ImageUrl;
            }
            return null;
        }
    }
}