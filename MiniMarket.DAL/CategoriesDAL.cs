using MiniMarket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMarket.DAL
{
    public class CategoriesDAL
    {
        MiniMarketContext _MiniMarketContext { get; set; }

        public CategoriesDAL(MiniMarketContext miniMarketContext)
        {
            _MiniMarketContext = miniMarketContext;
        }

        public List<Categories> GetAllCategories()
        {
            return _MiniMarketContext.Categories.ToList();
        }
    }
}