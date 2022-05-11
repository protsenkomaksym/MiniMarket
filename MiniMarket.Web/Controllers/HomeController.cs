using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarket.Business;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using MiniMarket.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MiniMarketContext _db { get; set; }
        IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, MiniMarketContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            List<CategoryDto> lstCat = categoriesBusiness.GetAllCategories();

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
