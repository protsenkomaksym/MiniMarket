using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarket.Business;
using MiniMarket.DAL.Models;
using MiniMarket.Entities.Dto;
using MiniMarket.Models;
using MiniMarket.Web.Models;
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
            return View();
        }

        public IActionResult Search(int? idCategory)
        {
            SearchViewModel model = new SearchViewModel();

            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = categoriesBusiness.GetAllCategories();
            model.idCategory = idCategory;
            model.lstItems = itemsBusiness.GetItemsByCategory(idCategory);

            return View(model);
        }

        public IActionResult Item(int id)
        {
            ItemViewModel model = new ItemViewModel();

            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            ItemDto i = itemsBusiness.GetItemsById(id);

            if (i == null)
            {
                return Redirect("~/");
            }
            else
            {
                model.Id = i.Id;
                model.Name = i.Name;
                model.Description = i.Description;
                model.Price = i.Price;
                model.Created = i.Created;
            }

            return View(model);
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult AddNewItem()
        {
            AddNewItemViewModel model = new AddNewItemViewModel();

            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            foreach (CategoryDto c in categoriesBusiness.GetAllCategories())
            {
                model.lstCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.name
                });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddNewItem(AddNewItemViewModel model)
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            // TODO: Create

            // Populate model again
            foreach (CategoryDto c in categoriesBusiness.GetAllCategories())
            {
                model.lstCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.name
                });
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
