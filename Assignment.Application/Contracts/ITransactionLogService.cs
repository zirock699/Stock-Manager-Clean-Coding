using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Application.Contracts
{
    public interface ITransactionLogService
    {
        void Add(TransactionLogEntry transactionLogEntry);
        ICollection<TransactionLogEntry> GetAll();
    }
}
