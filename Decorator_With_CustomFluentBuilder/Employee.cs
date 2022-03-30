using System;

namespace Decorator_With_CustomFluentBuilder
{
    public abstract class Employee
    {
        public int EmployeeId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Employee()
        {
        }
        ~Employee() { }
        public abstract void Work();
    }
}