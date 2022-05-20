using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniMarket.Entities;

namespace MiniMarket.Web.Helpers
{
    public static class OrderHeloper
    {
        public static List<SelectListItem> GetOrderList()
        {
            List<SelectListItem> lstOrder = new List<SelectListItem>();
            foreach (int val in Enum.GetValues(typeof(OrderEnum)))
            {
                var name = Enum.GetName(typeof(OrderEnum), val);
                lstOrder.Add(new SelectListItem() { 
                    Text = name,
                    Value = val.ToString()
                });
            }

            return lstOrder;
        }
    }
}
