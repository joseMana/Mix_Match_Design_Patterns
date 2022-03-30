using System;

namespace Decorator_With_CustomFluentBuilder
{
    public class ContractualEmployee : EmployeeDecorator
    {
        private Wage _wage;
        public ContractualEmployee() { }
        public ContractualEmployee(Employee employee) : base(employee)
        {
        }
        public ContractualEmployee SetPayRate(decimal rate)
        {
            _wage = _wage.SetRate(rate);
            return this;
        }
        public ContractualEmployee SetPayFrequency(WagePayFrequency payFrequency)
        {
            _wage = _wage.SetPayFrequency(payFrequency);
            return this;
        }
        public override void Payout()
        {
            base.Payout();
            Console.WriteLine(
                $"{_wage.GetPayFrequency().GetType().Name} Rate : {_wage.GetPayFrequency()}\n" +
                $"Rate : {_wage.GetPayRate()}\n");
        }
    }
}