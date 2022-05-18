using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Models
{
    public class AddNewItemViewModel
    {
        public int? id { get; set; }
        public List<SelectListItem> lstCategories { get; set; }
        public int? idCategory { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is Required")]
        public decimal? Price { get; set; }
    }
}
