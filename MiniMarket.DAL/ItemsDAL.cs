﻿using MiniMarket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMarket.DAL
{
    public class ItemsDAL
    {
        MiniMarketContext _MiniMarketContext { get; set; }

        public ItemsDAL(MiniMarketContext miniMarketContext)
        {
            _MiniMarketContext = miniMarketContext;
        }

        public List<Items> GetItemsByCategory(int? idCategory)
        {
            if (idCategory != null)
                return _MiniMarketContext.Items.Where(x => x.IdCategory == idCategory.GetValueOrDefault()).ToList();
            else
                return _MiniMarketContext.Items.ToList();
        }

        public Items GetItemById(int id)
        {
            return _MiniMarketContext.Items.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}