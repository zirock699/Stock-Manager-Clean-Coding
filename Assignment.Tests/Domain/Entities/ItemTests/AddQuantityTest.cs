using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Domain.Entities.ItemTests
{
    [TestClass]
    public class AddQuantityTest
    {
        [TestMethod]
        public void ShouldAddQuantitySuccessfully()
        {
            // Arrange
            var sut = new Item(1, "Pencil", 10, DateTime.Now);


            // Act
            sut.AddQuantity(4);

            // Assert
            Assert.AreEqual(14, sut.Quantity);

        }
    }
}
