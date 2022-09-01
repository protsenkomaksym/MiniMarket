using AutoMapper;
using MiniMarket.Business.Mapping;
using MiniMarket.DAL;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMarket.Business
{
    public class CategoriesBusiness
    {
        IMapper _mapper { get; set; }
        CategoriesDAL _categoriesDAL { get; set; }

        public CategoriesBusiness(MiniMarketContext miniMarketContext, 
            IMapper mapper,
            CategoriesDAL categoriesDAL)
        {
            _mapper = mapper;
            _categoriesDAL = categoriesDAL;
        }

        public List<CategoryDto> GetAllCategories()
        {
            List<Categories> categories = _categoriesDAL.GetAllCategories();

            return _mapper.Map<List<Categories>, List<CategoryDto>>(categories);
        }
    }
}
