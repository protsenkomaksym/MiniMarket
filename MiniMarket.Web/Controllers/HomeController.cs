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
        IMapper _mapper;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        ItemsBusiness _itemsBusiness;
        CategoriesBusiness _categoriesBusiness;

        public HomeController(ILogger<HomeController> logger, 
            MiniMarketContext db, 
            IMapper mapper,
            CategoriesBusiness backendBLL,
            ItemsBusiness itemsBusiness)
        {
            _logger = logger;
            _mapper = mapper;
            _categoriesBusiness = backendBLL;
            _itemsBusiness = itemsBusiness;
        }

        public IActionResult Index()
        {
            //Logger.Info("index body");
            IndexViewModel model = new IndexViewModel();
            model.lstItemsWithDiscount = _itemsBusiness.GetItemsWithDiscount();

            return View(model);
        }

        public IActionResult Search(int? idCategory, string q)
        {
            SearchViewModel model = new SearchViewModel();

            model.lstCategories = _categoriesBusiness.GetAllCategories();
            model.idCategory = idCategory;
            model.query = q;
            model.lstItems = _itemsBusiness.GetItemsByCategory(idCategory, 0, q);
            model.lstOrder = OrderHeloper.GetOrderList();
            model.order = (int)OrderEnum.None;

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            model.lstCategories = _categoriesBusiness.GetAllCategories();
            model.lstItems = _itemsBusiness.GetItemsByCategory(model.idCategory, model.order, model.query);
            model.lstOrder = OrderHeloper.GetOrderList();

            return View(model);
        }

        public IActionResult Item(int id)
        {
            ItemViewModel model = new ItemViewModel();

            ItemDto i = _itemsBusiness.GetItemsById(id);

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
                model.discount = i.discount;
            }

            return View(model);
        }

        public IActionResult Admin()
        {
            AdminViewModel model = new AdminViewModel();

            model.lstItems = _itemsBusiness.GetItemsByCategory(null, 0, null);

            return View(model);
        }

        public IActionResult NewItem(int? id)
        {
            AddNewItemViewModel model = new AddNewItemViewModel();

            model.lstCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            if (id != null)
            {
                ItemDto i = _itemsBusiness.GetItemsById(id.GetValueOrDefault());
                model.id = i.Id;
                model.Name = i.Name;
                model.Description = i.Description;
                model.Price = i.Price;
                model.idCategory = i.IdCategory;
                model.Discount = i.discount;
            }

            foreach (CategoryDto c in _categoriesBusiness.GetAllCategories())
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
                i.discount = model.Discount;

                if (model.id != null)
                {
                    // Update
                    _itemsBusiness.Update(i);
                }
                else
                {
                    // Create
                    _itemsBusiness.Create(i);
                }

                return RedirectToAction("Admin");
            }

            // Populate model again
            foreach (CategoryDto c in _categoriesBusiness.GetAllCategories())
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

            _itemsBusiness.Delete(id);

            return RedirectToAction("Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
