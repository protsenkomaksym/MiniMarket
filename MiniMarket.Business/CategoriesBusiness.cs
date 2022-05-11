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
        MiniMarketContext _MiniMarketContext { get; set; }
        IMapper _mapper { get; set; }

        public CategoriesBusiness(MiniMarketContext miniMarketContext, IMapper mapper)
        {
            _MiniMarketContext = miniMarketContext;
            _mapper = mapper;
        }

        public List<CategoryDto> GetAllCategories()
        {
            CategoriesDAL dal = new CategoriesDAL(_MiniMarketContext);
            List<Categories> categories = dal.GetAllCategories();

            return _mapper.Map<List<Categories>, List<CategoryDto>>(categories);
        }
    }
}
