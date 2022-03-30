using System;

namespace Factory_and_Singleton
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine(s1 == s2);

            Factory f1 = Factory.GetInstance();
            Factory f2 = Factory.GetInstance();
            Console.WriteLine(f1 == f2);
        }
    }
}
