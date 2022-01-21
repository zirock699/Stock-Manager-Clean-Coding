using Assignment.Domain.Entities;

namespace Assignment.Application.Contracts
{
    public interface IEmployeeService
    {
        Employee Find(string name);
    }
}
