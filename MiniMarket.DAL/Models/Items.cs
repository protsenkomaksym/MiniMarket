using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MiniMarket.DAL.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public DateTime Created { get; set; }

        public virtual Categories IdCategoryNavigation { get; set; }
    }
}
