using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Application.Services.TransactionLogServiceTests
{

    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void ShouldAddTransactionEntryLogSuccessfully()
        {
            // Arrange
            var sutBuilder = new SutBuilder();
            var newItem = new Item(1, "Pencil", 10, DateTime.Now);
            var newTransaction = new TransactionLogEntry("Item Added", newItem.Id, newItem.Name, 0.25m, newItem.Quantity, "Graham", DateTime.Now);
            var sut = sutBuilder.Build();

            // Act
            sut.Add(newTransaction);

            // Assert
            sutBuilder.VerifyAddIsCalled(newTransaction);
        }
    }
}
