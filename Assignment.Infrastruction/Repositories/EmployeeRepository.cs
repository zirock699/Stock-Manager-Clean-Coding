using Assignment.Domain.Contracts;
using Assignment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Infrastruction.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public Employee Find(string employeeName)
        {
            return _context.Employees.Where(x => x.Name == employeeName).SingleOrDefault();
        }

        public ICollection<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
