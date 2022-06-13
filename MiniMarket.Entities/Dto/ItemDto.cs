using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMarket.Entities.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public DateTime Created { get; set; }
        public int discount { get; set; }
    }
}
