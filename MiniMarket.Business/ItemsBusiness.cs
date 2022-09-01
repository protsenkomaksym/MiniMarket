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
        IMapper _mapper { get; set; }
        ItemsDAL _ItemsDAL { get; set; }

        public ItemsBusiness(IMapper mapper, ItemsDAL itemsDAL)
        {
            _mapper = mapper;
            _ItemsDAL = itemsDAL;
        }

        public List<ItemDto> GetItemsByCategory(int? idCategory, int order, string query)
        {
            List<Items> lstItems = _ItemsDAL.GetItemsByCategory(idCategory, query);

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
            Items i = _ItemsDAL.GetItemById(id);

            return _mapper.Map<Items, ItemDto>(i);
        }

        public void Create(ItemDto i)
        {
            _ItemsDAL.Create(_mapper.Map<ItemDto, Items>(i));
        }

        public void Update(ItemDto i)
        {
            Items idb = _ItemsDAL.GetItemById(i.Id);
            idb.Name = i.Name;
            idb.Description = i.Description;
            idb.Price = i.Price;
            idb.IdCategory = i.IdCategory;
            idb.discount = i.discount;

            _ItemsDAL.Update(idb);
        }

        public void Delete(int id)
        {
            Items idb = _ItemsDAL.GetItemById(id);

            _ItemsDAL.Delete(idb);
        }

        public List<ItemDto> GetItemsWithDiscount()
        {
            List<Items> lstItems = _ItemsDAL.GetItemsWithDiscount();

            return _mapper.Map<List<Items>, List<ItemDto>>(lstItems);
        }
    }
}
