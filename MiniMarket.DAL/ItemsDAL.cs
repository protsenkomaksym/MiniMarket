﻿using MiniMarket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.DAL
{
    public class ItemsDAL
    {
        MiniMarketContext _MiniMarketContext { get; set; }

        public ItemsDAL(MiniMarketContext miniMarketContext)
        {
            _MiniMarketContext = miniMarketContext;
        }

        public List<Items> GetItemsWithDiscount()
        {
            return _MiniMarketContext.Items.Where(x => x.discount > 0).ToList();
        }

        public List<Items> GetItemsByCategory(int? idCategory, string query)
        {
            return _MiniMarketContext.Items
                .Where(x => (idCategory == null || x.IdCategory == idCategory.GetValueOrDefault())
                    && ((string.IsNullOrEmpty(query) || x.Name.Contains(query))
                    || (string.IsNullOrEmpty(query) || x.Description.Contains(query))
                    )).ToList();
        }

        public Items GetItemById(int id)
        {
            return _MiniMarketContext.Items.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Items i)
        {
            _MiniMarketContext.Items.Add(i);
            _MiniMarketContext.SaveChanges();
        }

        public void Update(Items i)
        {
            _MiniMarketContext.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _MiniMarketContext.SaveChanges();
        }

        public void Delete(Items i)
        {
            _MiniMarketContext.Remove(i);
            _MiniMarketContext.SaveChanges();
        }
    }
}
