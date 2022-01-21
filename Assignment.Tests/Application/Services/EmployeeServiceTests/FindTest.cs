using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests.Application.Services.EmployeeServiceTests
{
    [TestClass]
    public class FindTest
    {
        [TestMethod]
        public void ShouldFindEmployeeSuccessfully()
        {
            // Arrange
            var sutBuilder = new SutBuilder();
            var employeeName = "Jan";
            var sut = sutBuilder.Build();

            // Act
            sut.Find(employeeName);

            // Assert
            sutBuilder.VerifyFindIsCalled(employeeName);
        }
    }
}
