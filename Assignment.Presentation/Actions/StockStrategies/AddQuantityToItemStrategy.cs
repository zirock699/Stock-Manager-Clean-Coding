using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System;

namespace Assignment.Presentation.Actions
{
    class AddQuantityToItemStrategy : IActionStrategy
    {
        private readonly IEmployeeService _employeeService;
        private readonly IItemService _itemService;
        private readonly ITransactionLogService _transactionLogService;
        private readonly IDateProvider _dateProvider;
        private readonly IConsoleReader _consoleReader;

        public AddQuantityToItemStrategy(IEmployeeService employeeService, IItemService itemService, ITransactionLogService transactionLogService, IDateProvider dateProvider, IConsoleReader consoleReader)
        {
            _employeeService = employeeService;
            _itemService = itemService;
            _transactionLogService = transactionLogService;
            _dateProvider = dateProvider;
            _consoleReader = consoleReader;
        }

        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["ADD_QUANTITY_TO_ITEM"].ItemNumber);
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
                Item item = _itemService.Find(itemId);
                if (item == null)
                {
                    throw new Exception("ERROR: Item not found");
                }

                int quantityToAdd = _consoleReader.ReadInteger("How many items would you like to add?");
                decimal itemPrice = _consoleReader.ReadDecimal("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }

                item.AddQuantity(quantityToAdd);
                Console.WriteLine(
                    "{0} items have been added to Item ID: {1} on {2}",
                    quantityToAdd,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                _transactionLogService.Add(
                    new TransactionLogEntry("Quantity Added", item.Id, item.Name, itemPrice, quantityToAdd, employeeName, DateTime.Now));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
