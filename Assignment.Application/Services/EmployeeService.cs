using Assignment.Application.Contracts;
using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;

namespace Assignment.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Find(string name)
        {
            return _employeeRepository.Find(name);
        }
    }
}
