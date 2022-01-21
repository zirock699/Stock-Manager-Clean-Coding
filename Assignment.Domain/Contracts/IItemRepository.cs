using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Domain.Contracts
{
    public interface IItemRepository
    {
        Item Add(Item item);
        Item Find(int id);
        ICollection<Item> GetAll();
    }
}
