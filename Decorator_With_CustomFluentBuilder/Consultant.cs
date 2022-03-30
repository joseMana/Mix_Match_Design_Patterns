using System;
using System.Collections.Generic;

namespace Decorator_With_CustomFluentBuilder
{
    public abstract class Consultant : Employee
    {
        public string ProjectName { get; set; }
        public List<string> MastersEngagement { get; set; }
        public override void Work()
        {
            Console.WriteLine($"Working for {ProjectName}");
        }
    }
}