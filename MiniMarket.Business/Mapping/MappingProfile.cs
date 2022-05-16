using AutoMapper;
using MiniMarket.DAL;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMarket.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categories, CategoryDto>();
            CreateMap<Items, ItemDto>();
        }
    }
}
