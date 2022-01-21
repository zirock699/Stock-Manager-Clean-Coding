using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Infrastruction.Repositories
{
    public class TransactionLogRepository : ITransactionLogRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TransactionLogEntry entry)
        {
            _context.TransactionLogEntries.Add(entry);
            _context.SaveChanges();
        }

        public ICollection<TransactionLogEntry> GetAll()
        {
            return _context.TransactionLogEntries.ToList();
        }
    }
}
