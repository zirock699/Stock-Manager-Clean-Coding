using Assignment.Application;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using Moq;

namespace Assignment.Tests.Application.Services.TransactionLogServiceTests
{
    public class SutBuilder
    {
        private readonly Mock<ITransactionLogRepository> _transactionLogRepository = new Mock<ITransactionLogRepository>();

        public TransactionLogService Build()
        {
            return new TransactionLogService(_transactionLogRepository.Object);
        }

        public void VerifyAddIsCalled(TransactionLogEntry transactionLog)
        {
            _transactionLogRepository.Verify(x => x.Add(transactionLog), Times.Once);
        }

        public void VerifyGetAllIsCalled()
        {
            _transactionLogRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
