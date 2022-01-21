using Assignment.Application.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Application
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public Item Find(int id)
        {
            return _itemRepository.Find(id);
        }

        public ICollection<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }
    }
}
