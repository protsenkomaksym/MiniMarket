using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarket.Business;
using MiniMarket.DAL.Models;
using MiniMarket.Entities;
using MiniMarket.Entities.Dto;
using MiniMarket.Models;
using MiniMarket.Web.Models;
using MiniMarket.Web.Helpers;
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
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public HomeController(ILogger<HomeController> logger, MiniMarketContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Logger.Info("index body");
            return View();
        }

        public IActionResult Search(int? idCategory, string q)
        {
            SearchViewModel model = new SearchViewModel();

            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = categoriesBusiness.GetAllCategories();
            model.idCategory = idCategory;
            model.query = q;
            model.lstItems = itemsBusiness.GetItemsByCategory(idCategory, 0, q);
            model.lstOrder = OrderHeloper.GetOrderList();
            model.order = (int)OrderEnum.None;

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = categoriesBusiness.GetAllCategories();
            model.lstItems = itemsBusiness.GetItemsByCategory(model.idCategory, model.order, model.query);
            model.lstOrder = OrderHeloper.GetOrderList();

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
            AdminViewModel model = new AdminViewModel();

            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstItems = itemsBusiness.GetItemsByCategory(null, 0, null);

            return View(model);
        }

        public IActionResult NewItem(int? id)
        {
            AddNewItemViewModel model = new AddNewItemViewModel();

            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            if (id != null)
            {
                ItemDto i = itemsBusiness.GetItemsById(id.GetValueOrDefault());
                model.id = i.Id;
                model.Name = i.Name;
                model.Description = i.Description;
                model.Price = i.Price;
                model.idCategory = i.IdCategory;
            }

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
        public IActionResult NewItem(AddNewItemViewModel model)
        {
            CategoriesBusiness categoriesBusiness = new CategoriesBusiness(_db, _mapper);
            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            model.lstCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            if (ModelState.IsValid)
            {
                // Create
                ItemDto i = new ItemDto();
                i.Id = model.id.GetValueOrDefault();
                i.Name = model.Name;
                i.Description = model.Description;
                i.Price = model.Price.GetValueOrDefault();
                i.IdCategory = model.idCategory.GetValueOrDefault();

                if(model.id != null)
                {
                    // Update
                    itemsBusiness.Update(i);
                }
                else
                {
                    // Create
                    itemsBusiness.Create(i);
                }

                return RedirectToAction("Admin");
            }

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

        public IActionResult Delete(int id)
        {
            ItemViewModel model = new ItemViewModel();

            ItemsBusiness itemsBusiness = new ItemsBusiness(_db, _mapper);
            itemsBusiness.Delete(id);

            return RedirectToAction("Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
