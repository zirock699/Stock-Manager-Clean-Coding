using Assignment.Application;
using Assignment.Domain.Contracts;
using Moq;

namespace Assignment.Tests.Application.Services.EmployeeServiceTests
{
    public class SutBuilder
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();

        public EmployeeService Build()
        {
            return new EmployeeService(_employeeRepository.Object);
        }

        public void VerifyFindIsCalled(string name)
        {
            _employeeRepository.Verify(x => x.Find(name), Times.Once);
        }
    }
}
