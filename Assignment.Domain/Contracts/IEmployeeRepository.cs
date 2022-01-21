using Assignment.Domain.Entities;
using System.Collections.Generic;

namespace Assignment.Domain.Contracts
{
    public interface IEmployeeRepository
    {
        void Add(Employee e);
        Employee Find(string EmpName);
        ICollection<Employee> GetAll();
    }
}
