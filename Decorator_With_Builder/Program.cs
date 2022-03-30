namespace Decorator_With_Builder
{
    public enum SalaryPayFrequency
    {
        Monthly,
        BiMonthly
    }
    public enum WagePayFrequency
    {
        Hourly,
        Daily,
        Weekly
    }
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
    public abstract class Consultant : Employee
    {
        public string ProjectName { get; set; }
        public List<string> MastersEngagement { get; set; }
        public override void Work()
        {
            Console.WriteLine($"Working for {ProjectName}");
        }
    }
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
    public class Developer : Consultant
    {
        public static int Id;
        public string ProgrammingLanguage { get; set; }
        private Developer()
        {

        }
        public override void Work()
        {
            base.Work();
            Console.WriteLine($"Writing code using {ProgrammingLanguage}\n");
        }
        public static Developer Create()//factory method
        {
            return new Developer();
        }
    }
    public class QualityEngineer : Consultant
    {
        public string TestingTool { get; set; }

        public override void Work()
        {
            base.Work();
            Console.WriteLine($"Doing tests using {TestingTool}\n");
        }
    }
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
    public static class ConsultantDecoratorBuilderExtension
    {
        public static TEmployeeDecorator DecorateAs<TEmployeeDecorator>(this Consultant c, Action<TEmployeeDecorator> typeInitializer)
            where TEmployeeDecorator : EmployeeDecorator, new()
        {
            var decorator = new TEmployeeDecorator();
            decorator.SetEmployee(c);

            typeInitializer(decorator);
            return decorator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer dev1 = Developer.Create();
            dev1.FirstName = "John";
            dev1.LastName = "Puruntong";
            dev1.ProjectName = "Fiserv Mainframe Offload";
            dev1.ProgrammingLanguage = "C#";
            dev1.MastersEngagement = new List<string> { "EF Core", "C#", "Xamarin" };
            var permanentDeveloper = dev1.DecorateAs<ContractualEmployee>(c =>
            {
                c.SetPayFrequency(WagePayFrequency.Daily);
                c.SetPayRate(500);
            });

            QualityEngineer qe = new QualityEngineer();
            qe.FirstName = "Billy";
            qe.LastName = "Puruntong";
            qe.ProjectName = "EY";
            qe.TestingTool = "Tricentis Tosca";
            qe.MastersEngagement = new List<string> { "Selenium Framework", "NeoLoad Automation" };
            var contractualQe = qe.DecorateAs<PermanentEmployee>(c =>
            {
                c.SetPayFrequency(SalaryPayFrequency.BiMonthly);
                c.SetSalaryValue(30000);
            });

            Console.ReadLine();
        }
    }
}