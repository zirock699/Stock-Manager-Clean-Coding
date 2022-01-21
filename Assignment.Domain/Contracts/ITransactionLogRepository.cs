using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Domain.Contracts
{
    public interface ITransactionLogRepository
    {
        void Add(TransactionLogEntry transactionLog);
        ICollection<TransactionLogEntry> GetAll();
    }
}
