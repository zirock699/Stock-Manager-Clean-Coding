using Assignment.Application;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using Moq;

namespace Assignment.Tests.Application.Services.ItemServiceTests
{
    public class SutBuilder
    {
        private readonly Mock<IItemRepository> _itemRepository = new Mock<IItemRepository>();

        public ItemService Build()
        {
            return new ItemService(_itemRepository.Object);
        }

        public void VerifyAddIsCalled(Item item)
        {
            _itemRepository.Verify(x => x.Add(item), Times.Once);
        }

        public void VerifyGetAllIsCalled()
        {
            _itemRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
