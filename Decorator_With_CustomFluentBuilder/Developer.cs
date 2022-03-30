using System;

namespace Decorator_With_CustomFluentBuilder
{
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
}