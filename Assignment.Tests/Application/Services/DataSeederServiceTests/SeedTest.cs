using Assignment.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests.Application.Services.DataSeederServiceTests
{
    [TestClass]
    public class SeedTest
    {
        [TestMethod]
        public void ShouldSeedDataSuccessfully()
        {
            // Arrange
            var sutBuilder = new SutBuilder();

            var items = Array.Empty<Item>();
            var employees = Array.Empty<Employee>();

            var sut = sutBuilder.WithGetAllEmployeesReturn(employees)
                                .WithGetAllItemsReturn(items)
                                .Build();

            // Act
            sut.Seed();

            // Assert
            sutBuilder.VerifyAddEmployeeIsCalled();
            sutBuilder.VerifyAddItemIsCalled();
            sutBuilder.VerifyAddTransactionLogIsCalled();
            sutBuilder.VerifyDateNowIsCalled();
        }
    }
}
