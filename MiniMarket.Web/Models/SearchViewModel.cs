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
        public List<ItemDto> lstItems { get; set; }
    }
}
