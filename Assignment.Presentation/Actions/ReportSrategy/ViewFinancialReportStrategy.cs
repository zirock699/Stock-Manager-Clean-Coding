using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Entities;
using System;


namespace Assignment.Presentation.Actions
{
    public class ViewFinancialReportStrategy : IActionStrategy
    {

        private readonly ITransactionLogService _transactionLogService;
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        public ViewFinancialReportStrategy(ITransactionLogService transactionLogService, IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {

            _transactionLogService = transactionLogService;
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
        }

        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["VIEW_FINANCIAL_REPORT"].ItemNumber);
        public int? ActionType => InMenuOptionNumber;

        public void Excute()
        {

            decimal total = 0;

            _consoleWriter.WriteLine("\nFinancial Report:");
            var line = string.Format("{0}{1, 10}", "---------", "----");

            var header = string.Format("|{0}{1, 10}", "Item name", "Cost");
            _consoleWriter.WriteLine(header);

            _consoleWriter.WriteLine(line);
            foreach (TransactionLogEntry entry in _transactionLogService.GetAll())
            {
                if (entry.TypeOfTransaction.Equals("Item Added")
                    || entry.TypeOfTransaction.Equals("Quantity Added"))
                {
                    decimal cost = entry.ItemPrice * entry.Quantity;
                    var row = string.Format("|{0}:£{1, 10}", entry.ItemName, cost);
                    _consoleWriter.WriteLine(row);


                    total += cost;
                }
            }
            _consoleWriter.WriteLine(line);
            var footer = string.Format("{0} {1, 10} \n", "Total: ", total);
            _consoleWriter.WriteLine(footer);


        }
    }

}
