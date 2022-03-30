using System;

namespace Decorator_With_CustomFluentBuilder
{
    public class QualityEngineer : Consultant
    {
        public string TestingTool { get; set; }

        public override void Work()
        {
            base.Work();
            Console.WriteLine($"Doing tests using {TestingTool}\n");
        }
    }
}