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
    public class MainMenuPartialComponent: ViewComponent
    {
        MiniMarketContext _db { get; set; }
        IMapper _mapper;

        public MainMenuPartialComponent(MiniMarketContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            List<CategoryDto> lstCat = categoriesBusiness.GetAllCategories();

            return View("~/Views/Components/_MainMenuPartial.cshtml", lstCat);
        }
    }
}
