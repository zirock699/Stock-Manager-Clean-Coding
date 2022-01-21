using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests.Application.Services.ItemServiceTests
{

    [TestClass]
    public class GetAllTest
    {
        [TestMethod]
        public void ShouldGetAllItemsSuccessfully()
        {
            // Arrange
            var sutBuilder = new SutBuilder();

            var sut = sutBuilder.Build();

            // Act
            sut.GetAll();

            // Assert
            sutBuilder.VerifyGetAllIsCalled();
        }
    }
}
