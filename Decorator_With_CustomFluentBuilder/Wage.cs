namespace Decorator_With_CustomFluentBuilder
{
    public readonly struct Wage
    {
        private readonly decimal _payRate;
        private readonly WagePayFrequency _payFrequency;
        public Wage(decimal payRate, WagePayFrequency payFrequency)
        {
            _payRate = payRate;
            _payFrequency = payFrequency;
        }
        public Wage SetRate(decimal rate)
        {
            return new Wage(rate, this._payFrequency);
        }
        public Wage SetPayFrequency(WagePayFrequency payFrequency)
        {
            return new Wage(this._payRate, payFrequency);
        }
        public decimal GetPayRate() => _payRate;
        public WagePayFrequency GetPayFrequency() => _payFrequency;
    }
}