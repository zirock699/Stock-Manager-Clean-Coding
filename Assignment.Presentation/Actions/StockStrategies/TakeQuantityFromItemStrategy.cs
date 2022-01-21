using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System;

namespace Assignment.Presentation.Actions
{
    class TakeQuantityFromItemStrategy : IActionStrategy
    {
        private readonly IEmployeeService _employeeService;
        private readonly IItemService _itemService;
        private readonly ITransactionLogService _transactionLogService;
        private readonly IDateProvider _dateProvider;
        private readonly IConsoleReader _consoleReader;

        public TakeQuantityFromItemStrategy(IEmployeeService employeeService, IItemService itemService, ITransactionLogService transactionLogService, IDateProvider dateProvider, IConsoleReader consoleReader)
        {
            _employeeService = employeeService;
            _itemService = itemService;
            _transactionLogService = transactionLogService;
            _dateProvider = dateProvider;
            _consoleReader = consoleReader;
        }

        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["TAKE_QUANTITY_FROM_ITEM"].ItemNumber);
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

                int quantityToRemove = _consoleReader.ReadInteger("How many items would you like to remove?");

                item.RemoveQuantity(quantityToRemove);
                Console.WriteLine(
                    "{0} has removed {1} of Item ID: {2} on {3}",
                    employeeName,
                    quantityToRemove,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                _transactionLogService.Add(
                    new TransactionLogEntry("Quantity Removed", item.Id, item.Name, -1, quantityToRemove, employeeName, DateTime.Now));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
