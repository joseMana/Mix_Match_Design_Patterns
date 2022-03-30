using System;

namespace Decorator_With_CustomFluentBuilder
{
    public class EmployeeDecorator : Employee
    {
        Employee _employee = null;
        public EmployeeDecorator() { }
        public EmployeeDecorator(Employee employee)
        {
            this._employee = employee;
        }
        public virtual void Payout()
        {
            Console.WriteLine($"EmployeeId: {_employee.EmployeeId}\nEmployee type: {base.GetType().Name}");
        }
        public void SetEmployee(Employee employee)
        {
            this._employee = employee;
        }
        public override void Work()
        {
            _employee.Work();
        }

    }
}