using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarket.Web.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public DateTime Created { get; set; }
    }
}
