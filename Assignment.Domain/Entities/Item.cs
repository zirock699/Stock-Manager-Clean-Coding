using System;

namespace Assignment.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; private set; }
        public DateTime DateCreated { get; set; }
        public Item()
        {

        }
        public Item(int id, string name, int quantity, DateTime creationDate)
        {
            string errorMsg = "";

            if (id < 1)
            {
                errorMsg += "ID below 1; ";
            }

            if (quantity < 1)
            {
                errorMsg += "Quantity below 1; ";
            }

            if (name.Length == 0)
            {
                errorMsg += "Item name is empty; ";
            }

            if (errorMsg.Length > 0)
            {
                throw new Exception("ERROR: " + errorMsg);
            }

            Id = id;
            Name = name;
            Quantity = quantity;
            DateCreated = creationDate;
        }

        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being added is below 0");
            }

            Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being removed is below 0");
            }

            if (quantity > Quantity)
            {
                throw new Exception("ERROR: Quantity too many");
            }

            Quantity -= quantity;
        }
    }
}
