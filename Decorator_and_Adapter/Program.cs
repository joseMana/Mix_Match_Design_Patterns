using System;

namespace Decorator_and_Adapter
{
    internal class Program
    {
        public static void Main()
        {
            Car car = new Sportscar();
            Decorator decorator = new Decorator(car);
            decorator.Drive();
        }
    }
}
