using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Models
{
    public class AddNewItemViewModel
    {
        public List<SelectListItem> lstCategories { get; set; }
        public int? idCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
