using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarket.Business;
using MiniMarket.DAL;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        MiniMarketContext _db { get; set; }
        IMapper _mapper;
        CategoriesBusiness _categoriesBusiness;
        ItemsBusiness _itemsBusiness;

        public HomeController(ILogger<HomeController> logger,
            MiniMarketContext db,
            IMapper mapper,
            CategoriesBusiness categoriesBusiness,
            ItemsBusiness itemsBusiness)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
            _categoriesBusiness = categoriesBusiness;
            _itemsBusiness = itemsBusiness;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_categoriesBusiness.GetAllCategories());
        }

        [HttpGet]
        [Route("GetItemsByCategory/{id}")]
        public IActionResult GetItemsByCategory(int id)
        {
            return Ok(_itemsBusiness.GetItemsByCategory(id, 0, null));
        }
    }
}
