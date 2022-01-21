using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Application.Services.ItemServiceTests
{

    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void ShouldAddItemSuccessfully()
        {
            // Arrange
            var sutBuilder = new SutBuilder();
            var newItem = new Item(1, "Pencil", 10, DateTime.Now);

            var sut = sutBuilder.Build();

            // Act
            sut.Add(newItem);

            // Assert
            sutBuilder.VerifyAddIsCalled(newItem);
        }
    }
}
