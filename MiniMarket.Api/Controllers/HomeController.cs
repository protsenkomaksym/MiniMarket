using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarket.Business;
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

        public HomeController(ILogger<HomeController> logger, MiniMarketContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            return Ok(categoriesBusiness.GetAllCategories());
        }

        [HttpGet]
        [Route("GetItemsByCategory/{id}")]
        public IActionResult GetItemsByCategory(int id)
        {
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            return Ok(itemsBusiness.GetItemsByCategory(id, 0, null));
        }
    }
}
