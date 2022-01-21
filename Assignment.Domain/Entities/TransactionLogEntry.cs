using System;

namespace Assignment.Domain.Entities
{
    public class TransactionLogEntry
    {
        public string TypeOfTransaction { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateAdded { get; set; }

        public TransactionLogEntry()
        {

        }
        public TransactionLogEntry(string type, int itemID, string itemName, decimal itemPrice, int quantity, string employeeName, DateTime dateAdded)
        {
            TypeOfTransaction = type;
            ItemID = itemID;
            ItemName = itemName;
            ItemPrice = itemPrice;
            Quantity = quantity;
            EmployeeName = employeeName;
            DateAdded = dateAdded;
        }
    }
}
