using Assignment.Application;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace Assignment.Tests.Application.Services.DataSeederServiceTests
{
    public class SutBuilder
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();
        private readonly Mock<IItemRepository> _itemRepository = new Mock<IItemRepository>();
        private readonly Mock<ITransactionLogRepository> _transactionLogRepository = new Mock<ITransactionLogRepository>();
        private readonly Mock<IDateProvider> _dateProvider = new Mock<IDateProvider>();

        public SutBuilder WithGetAllEmployeesReturn(ICollection<Employee> employees)
        {
            _employeeRepository.Setup(x => x.GetAll()).Returns(employees);
            return this;
        }

        public SutBuilder WithGetAllItemsReturn(ICollection<Item> items)
        {
            _itemRepository.Setup(x => x.GetAll()).Returns(items);
            return this;
        }

        public DataSeederService Build()
        {
            return new DataSeederService(_employeeRepository.Object, _itemRepository.Object, _transactionLogRepository.Object, _dateProvider.Object);
        }

        public void VerifyAddEmployeeIsCalled()
        {
            _employeeRepository.Verify(x => x.Add(It.IsAny<Employee>()), Times.Exactly(3));
        }

        public void VerifyAddItemIsCalled()
        {
            _itemRepository.Verify(x => x.Add(It.IsAny<Item>()), Times.Exactly(2));
        }

        public void VerifyAddTransactionLogIsCalled()
        {
            _transactionLogRepository.Verify(x => x.Add(It.IsAny<TransactionLogEntry>()), Times.Exactly(4));
        }

        public void VerifyDateNowIsCalled()
        {
            _dateProvider.Verify(x => x.Now(), Times.Exactly(6));
        }
    }
}
