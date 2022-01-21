using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Domain.Entities.ItemTests
{
    [TestClass]
    public class RemoveQuantityTest
    {
        [TestMethod]
        public void ShouldRemoveQuantity()
        {
            // Arrange
            var sut = new Item(1, "Pencil", 10, DateTime.Now);


            // Act
            sut.RemoveQuantity(4);

            // Assert
            Assert.AreEqual(6, sut.Quantity);
        }
    }
}
