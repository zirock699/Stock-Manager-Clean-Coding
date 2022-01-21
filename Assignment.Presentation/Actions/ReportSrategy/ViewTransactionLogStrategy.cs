using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Entities;
using System;

namespace Assignment.Presentation.Actions
{
    public class ViewTransactionLogStrategy : IActionStrategy
    {

        private readonly ITransactionLogService _transactionLogService;

        private readonly IConsoleWriter _consoleWriter;



        public ViewTransactionLogStrategy(ITransactionLogService transactionLogService, IConsoleWriter consoleWriter)
        {

            _transactionLogService = transactionLogService;

            _consoleWriter = consoleWriter;
        }


        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["VIEW_TRANSACTION_LOG"].ItemNumber);
        public int? ActionType => InMenuOptionNumber;

        public void Excute()
        {
            var tls = _transactionLogService.GetAll();

            _consoleWriter.WriteLine("\nTransaction Log:");
            var header = string.Format(
                "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Quantity",
                "Employee",
                "Price");
            _consoleWriter.WriteLine(header);

            foreach (TransactionLogEntry entry in tls)
            {
                var row = string.Format(
                    "\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    entry.DateAdded.ToString("dd/MM/yyyy"),
                    entry.TypeOfTransaction,
                    entry.ItemID,
                    entry.ItemName,
                    entry.Quantity,
                    entry.EmployeeName,
                    entry.TypeOfTransaction.Equals("Quantity Removed") ? "" : "" + string.Format("{0:C}", entry.ItemPrice));
                _consoleWriter.WriteLine(row);
            }
        }
    }
}
