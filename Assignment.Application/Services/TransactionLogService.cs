using Assignment.Application.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Application
{
    public class TransactionLogService : ITransactionLogService
    {
        private readonly ITransactionLogRepository _transactionLogRepository;

        public TransactionLogService(ITransactionLogRepository transactionLogRepository)
        {
            _transactionLogRepository = transactionLogRepository;
        }

        public void Add(TransactionLogEntry transactionLogEntry)
        {
            _transactionLogRepository.Add(transactionLogEntry);
        }

        public ICollection<TransactionLogEntry> GetAll()
        {
            return _transactionLogRepository.GetAll();
        }
    }
}
