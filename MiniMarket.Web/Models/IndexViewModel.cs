using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Models
{
    public class IndexViewModel
    {
        public List<ItemDto> lstItemsWithDiscount { get; set; }
    }
}
