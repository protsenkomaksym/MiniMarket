using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniMarket.Business;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Views.Components
{
    public class MainMenuPartialComponent : ViewComponent
    {
        MiniMarketContext _db { get; set; }
        IMapper _mapper;
        CategoriesBusiness _categoriesBusiness { get; set; }

        public MainMenuPartialComponent(MiniMarketContext db, 
            IMapper mapper,
            CategoriesBusiness categoriesBusiness)
        {
            _db = db;
            _mapper = mapper;
            _categoriesBusiness = categoriesBusiness;
        }

        public IViewComponentResult Invoke()
        {
            List<CategoryDto> lstCat = _categoriesBusiness.GetAllCategories();

            return View("~/Views/Components/_MainMenuPartial.cshtml", lstCat);
        }
    }
}
