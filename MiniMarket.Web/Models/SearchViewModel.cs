using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Models
{
    public class SearchViewModel
    {
        public List<CategoryDto> lstCategories { get; set; }
        public int? idCategory { get; set; }
        public string query { get; set; }
        public List<ItemDto> lstItems { get; set; }
        public List<SelectListItem> lstOrder { get; set; }
        public int order { get; set; }
    }
}
