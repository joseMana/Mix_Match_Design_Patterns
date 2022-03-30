using System;

namespace Decorator_With_CustomFluentBuilder
{
    public class PermanentEmployee : EmployeeDecorator
    {
        private Salary _salary = new Salary();
        public PermanentEmployee() { }
        public PermanentEmployee(Employee employee) : base(employee) { }
        public PermanentEmployee SetSalaryValue(decimal salaryValue)
        {
            _salary = _salary.SetSalaryValue(salaryValue);
            return this;
        }
        public PermanentEmployee SetPayFrequency(SalaryPayFrequency payFrequency)
        {
            _salary = _salary.SetPayFrequency(payFrequency);
            return this;
        }
        public override void Payout()
        {
            base.Payout();
            Console.WriteLine(
                $"Salary Schedule: {_salary.GetSalaryValue()}\n" +
                $"Salary Value: {_salary.GetSalarySchedule()}");
        }
    }
}