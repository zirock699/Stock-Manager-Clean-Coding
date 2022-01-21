namespace Assignment.Domain.Entities
{
    public class Employee
    {
        public string Name { get; set; }

        public Employee() { }
        public Employee(string name)
        {
            Name = name;
        }
    }
}
