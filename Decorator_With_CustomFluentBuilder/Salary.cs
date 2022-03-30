namespace Decorator_With_CustomFluentBuilder
{
    public readonly struct Salary
    {
        private readonly decimal _salaryValue;
        private readonly SalaryPayFrequency _payFrequency;
        public Salary(decimal salaryValue)
            : this(salaryValue, SalaryPayFrequency.BiMonthly)
        {
        }
        public Salary(decimal salaryValue, SalaryPayFrequency payFrequency)
        {
            _salaryValue = salaryValue;
            _payFrequency = payFrequency;
        }
        public Salary SetSalaryValue(decimal salaryValue)
        {
            return new Salary(salaryValue, this._payFrequency);
        }
        public Salary SetPayFrequency(SalaryPayFrequency payFrequency)
        {
            return new Salary(this._salaryValue, payFrequency);
        }
        public decimal GetSalaryValue() => _salaryValue;
        public SalaryPayFrequency GetSalarySchedule() => _payFrequency;
    }
}