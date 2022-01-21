using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Domain.Entities;
using Assignment.Presentation.Actions;
using System;

namespace Assignment.Presentation
{
    public class ViewPersonalUsageReportStrategy : IActionStrategy
    {

        private readonly ITransactionLogService _transactionLogService;
        private readonly IConsoleReader _consoleReader;
        private readonly IConsoleWriter _consoleWriter;
        public ViewPersonalUsageReportStrategy(ITransactionLogService transactionLogService, IConsoleReader consoleReader, IConsoleWriter consoleWriter)
        {
            _transactionLogService = transactionLogService;
            _consoleReader = consoleReader;
            _consoleWriter = consoleWriter;
        }




        private int InMenuOptionNumber = Convert.ToInt32(Menu.GetMenu()["VIEW_PERSONAL_USAGE_REPORT"].ItemNumber);
        public int? ActionType => InMenuOptionNumber;

        public void Excute()
        {
            string employeeName = _consoleReader.ReadString("Employee name");

            _consoleWriter.WriteLine($"\nPersonal Usage Report for {employeeName}");
            var header = string.Format(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed");

            _consoleWriter.WriteLine(header);

            foreach (TransactionLogEntry entry in _transactionLogService.GetAll())
            {
                if (entry.TypeOfTransaction.Equals("Quantity Removed") && entry.EmployeeName == employeeName)
                {
                    var row = string.Format(
                        "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                        entry.DateAdded,
                        entry.ItemID,
                        entry.ItemName,
                        entry.Quantity);
                    _consoleWriter.WriteLine(row);
                }
            }
        }


    }
}
