using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Domain.Entities.ItemTests
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void ShouldCreateInstanceOfItem()
        {
            // Arrange / Act
            var sut = new Item(1, "itemName", 1, new DateTime(2022, 01, 01));

            // Assert
            Assert.AreEqual(sut.Name, "itemName");
            Assert.AreEqual(sut.Id, 1);
            Assert.AreEqual(sut.Quantity, 1);
        }

        [DataTestMethod]
        [DataRow(0, 1, "itemName", "ERROR: ID below 1; ")]
        [DataRow(1, 0, "itemName", "ERROR: Quantity below 1; ")]
        [DataRow(1, 1, "", "ERROR: Item name is empty; ")]
        public void ShouldThrowExceptionWithMessage(int id, int quantity, string name, string errorMessage)
        {
            // Arrange/Act/Assert

            var exception = Assert.ThrowsException<Exception>(() => new Item(id, name, quantity, DateTime.Now));
            Assert.AreEqual(errorMessage, exception.Message);
        }
    }
}
