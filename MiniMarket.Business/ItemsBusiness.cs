using AutoMapper;
using MiniMarket.Business.Mapping;
using MiniMarket.DAL;
using MiniMarket.DAL.Models;
using MiniMarket.Entities;
using MiniMarket.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMarket.Business
{
    public class ItemsBusiness
    {
        MiniMarketContext _MiniMarketContext { get; set; }
        IMapper _mapper { get; set; }

        public ItemsBusiness(MiniMarketContext miniMarketContext, IMapper mapper)
        {
            _MiniMarketContext = miniMarketContext;
            _mapper = mapper;
        }

        public List<ItemDto> GetItemsByCategory(int? idCategory, int order, string query)
        {
            ItemsDAL dal = new ItemsDAL(_MiniMarketContext);
            List<Items> lstItems = dal.GetItemsByCategory(idCategory, query);

            if(order == (int)OrderEnum.Asc)
            {
                lstItems = lstItems.OrderBy(x => x.Price).ToList();
            }
            else if (order == (int)OrderEnum.Desc)
            {
                lstItems = lstItems.OrderByDescending(x => x.Price).ToList();
            }

            return _mapper.Map<List<Items>, List<ItemDto>>(lstItems);
        }

        public ItemDto GetItemsById(int id)
        {
            ItemsDAL dal = new ItemsDAL(_MiniMarketContext);
            Items i = dal.GetItemById(id);

            return _mapper.Map<Items, ItemDto>(i);
        }

        public void Create(ItemDto i)
        {
            ItemsDAL dal = new ItemsDAL(_MiniMarketContext);
            dal.Create(_mapper.Map<ItemDto, Items>(i));
        }

        public void Update(ItemDto i)
        {
            ItemsDAL dal = new ItemsDAL(_MiniMarketContext);

            Items idb = dal.GetItemById(i.Id);
            idb.Name = i.Name;
            idb.Description = i.Description;
            idb.Price = i.Price;
            idb.IdCategory = i.IdCategory;

            dal.Update(idb);
        }

        public void Delete(int id)
        {
            ItemsDAL dal = new ItemsDAL(_MiniMarketContext);

            Items idb = dal.GetItemById(id);

            dal.Delete(idb);
        }
    }
}
