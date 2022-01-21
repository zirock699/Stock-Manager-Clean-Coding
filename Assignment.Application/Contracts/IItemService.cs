using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Application.Contracts
{
    public interface IItemService
    {
        Item Add(Item item);
        Item Find(int id);
        ICollection<Item> GetAll();
    }
}
