using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Infrastruction.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Item Find(int id)
        {
            return _context.Items.Where(x => x.Id == id).SingleOrDefault();
        }

        public Item Add(Item item)
        {
            if (Find(item.Id) != null)
            {
                throw new Exception("Item is already in stock. Quantity NOT updated");
            }

            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ICollection<Item> GetAll()
        {
            return _context.Items.ToList();
        }
    }
}
