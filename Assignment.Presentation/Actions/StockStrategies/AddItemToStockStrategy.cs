using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System;

namespace Assignment.Presentation.Actions
{
    class AddItemToStockStrategy : IActionStrategy
    {
        private readonly IEmployeeService _employeeService;
        private readonly IItemService _itemService;
        private readonly ITransactionLogService _transactionLogService;
        private readonly IDateProvider _dateProvider;
        private readonly IConsoleReader _consoleReader;

        public AddItemToStockStrategy(IEmployeeService employeeService, IItemService itemService, ITransactionLogService transactionLogService, IDateProvider dateProvider, IConsoleReader consoleReader)
        {
            _employeeService = employeeService;
            _itemService = itemService;
            _transactionLogService = transactionLogService;
            _dateProvider = dateProvider;
            _consoleReader = consoleReader;
        }



        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["ADD_ITEM_TO_STOCK"].ItemNumber);
        public int? ActionType => InMenuOptionNumber;


        public void Excute()
        {
            try
            {
                string employeeName = _consoleReader.ReadString("\nEmployee Name");
                if (_employeeService.Find(employeeName) == null)
                {
                    throw new Exception("ERROR: Employee not found");
                }

                int itemId = _consoleReader.ReadInteger("Item ID");
                string itemName = _consoleReader.ReadString("Item Name");
                int itemQuantity = _consoleReader.ReadInteger("Item Quantity");
                decimal itemPrice = _consoleReader.ReadDecimal("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }

                Item i = _itemService.Add(new Item(itemId, itemName, itemQuantity, _dateProvider.Now()));
                _transactionLogService.Add(
                    new TransactionLogEntry("Item Added", i.Id, i.Name, itemPrice, i.Quantity, employeeName, _dateProvider.Now()));

                Console.WriteLine("Item Added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
