using System;

namespace Decorator_and_Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //Hint: You can create a decorator class that wraps the original object, and the adapter class that changes the interface of the original object.
    //In this exercise, you will create a decorator class that changes the interface of an existing object.

    //Create a decorator class that changes the interface of an existing object.

    //Example:

    class Car
    {
        public virtual void Drive() { }
    }

    class Sportscar : Car
    {
        public override void Drive() { }
    }

    class Decorator : Car
    {
        protected Car car;

        public Decorator(Car car)
        {
            this.car = car;
        }

        public override void Drive()
        {
            this.car.Drive();
        }
    }

    class DecoratorTest
    {
        public static void Main()
        {
            Car car = new Sportscar();
            Decorator decorator = new Decorator(car);
            decorator.Drive();
        }
    }

    //When you decorate an object, you can add new functionality to it without altering its original behavior.

    //You can also use decorator to change the behavior of an object without altering its interface.

    //Solution
    //class Car
    //{
    //    public virtual void Drive() { }
    //}

    //class Sportscar : Car
    //{
    //    public override void Drive() { }
    //}

    //class Decorator : Car
    //{
    //    protected Car car;

    //    public Decorator(Car car)
    //    {
    //        this.car = car;
    //    }

    //    public override void Drive()
    //    {
    //        this.car.Drive();
    //    }
    //}

    //class DecoratorTest
    //{
    //    public static void Main()
    //    {
    //        Car car = new Sportscar();
    //        Decorator decorator = new Decorator(car);
    //        decorator.Drive();
    //    }
    //}


}
