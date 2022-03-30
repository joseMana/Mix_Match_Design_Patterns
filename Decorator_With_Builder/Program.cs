using System;
using System.Collections.Generic;

namespace Decorator_With_CustomFluentBuilder
{
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