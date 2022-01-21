using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Entities;
using System;

namespace Assignment.Presentation.Actions
{
    public class ViewInventoryReportsStrategy : IActionStrategy
    {
        private readonly IItemService _itemService;
        private readonly ITransactionLogService _transactionLogService;
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        public ViewInventoryReportsStrategy(IItemService itemService, ITransactionLogService transactionLogService, IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {
            _itemService = itemService;
            _transactionLogService = transactionLogService;
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
        }


        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["VIEW_INVENTORY_REPORT"].ItemNumber);
        public int? ActionType => InMenuOptionNumber;


        public void Excute()
        {
            _consoleWriter.WriteLine("\nAll items");
            var header = string.Format(
                "\t{0, -4} {1, -20} {2, -20}",
                "ID",
                "Name",
                "Quantity");
            _consoleWriter.WriteLine(header);

            foreach (Item i in _itemService.GetAll())
            {
                var row = string.Format(
                    "\t{0, -4} {1, -20} {2, -20}",
                    i.Id,
                    i.Name,
                    i.Quantity);
                _consoleWriter.WriteLine(row);
            }
        }

    }
}
