using Assignment.Application.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;

namespace Assignment.Application
{
    // This a service to seed the initial data to the database
    public class DataSeederService : IDataSeederService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ITransactionLogRepository _transactionLogRepository;
        private readonly IDateProvider _dateProvider;

        ///Inject dependecies to this class using the interface 
        public DataSeederService(IEmployeeRepository employeeRepository, IItemRepository itemRepository, ITransactionLogRepository transactionLogRepository = null, IDateProvider dateProvider = null)
        {
            _employeeRepository = employeeRepository;
            _itemRepository = itemRepository;
            _transactionLogRepository = transactionLogRepository;
            _dateProvider = dateProvider;
        }

        public void Seed()
        {
            /// As we are using database that persiste that we need to check
            /// if the database has no employees before inserting them to avoid duplicate
            if (_employeeRepository.GetAll().Count == 0)
            {

                _employeeRepository.Add(new Employee("Graham"));
                _employeeRepository.Add(new Employee("Phil"));
                _employeeRepository.Add(new Employee("Jan"));
            }
            /// check if we already inserted the initial items
            if (_itemRepository.GetAll().Count == 0)
            {

                var pencilItem = new Item(1, "Pencil", 10, _dateProvider.Now());
                _itemRepository.Add(pencilItem);
                var pencilTransactionLog = new TransactionLogEntry("Item Added", pencilItem.Id, pencilItem.Name, 0.25m, pencilItem.Quantity, "Graham", _dateProvider.Now());
                _transactionLogRepository.Add(pencilTransactionLog);

                var eraserItem = new Item(2, "Eraser", 20, _dateProvider.Now());
                _itemRepository.Add(eraserItem);
                var eraserTransactionLog = new TransactionLogEntry("Item Added", eraserItem.Id, eraserItem.Name, 0.15m, eraserItem.Quantity, "Phil", _dateProvider.Now());
                _transactionLogRepository.Add(eraserTransactionLog);

                eraserItem.RemoveQuantity(4);
                var eraserQuantityRemoved = new TransactionLogEntry("Quantity Removed", eraserItem.Id, eraserItem.Name, -1, 4, "Graham", _dateProvider.Now());
                _transactionLogRepository.Add(eraserQuantityRemoved);

                eraserItem.AddQuantity(2);
                var eraserQuantityAdded = new TransactionLogEntry("Quantity Added", eraserItem.Id, eraserItem.Name, 0.33m, 2, "Phil", _dateProvider.Now());
                _transactionLogRepository.Add(eraserQuantityAdded);
            }

        }
    }
}
