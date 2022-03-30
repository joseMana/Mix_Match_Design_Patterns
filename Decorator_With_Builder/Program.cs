using System;

namespace Decorator_With_Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //Decorator with Builder if you need to build a complex object and you want to be able to change the object's structure during runtime.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
    {
        class Program
        {
            static void Main(string[] args)
            {
                var car = new CarBuilder();
                var carDecorator = new CarDecorator(car);
                carDecorator.Build();
                Console.WriteLine(carDecorator);
            }
        }

        public interface ICarBuilder
        {
            void BuildFrame();
            void BuildEngine();
            void BuildWheels();
            void BuildDoors();
        }

        public class CarBuilder : ICarBuilder
        {
            public void BuildFrame()
            {
                Console.WriteLine("Car frame is built");
            }

            public void BuildEngine()
            {
                Console.WriteLine("Car engine is built");
            }

            public void BuildWheels()
            {
                Console.WriteLine("Car wheels are built");
            }

            public void BuildDoors()
            {
                Console.WriteLine("Car doors are built");
            }
        }

        public class CarDecorator : ICarBuilder
        {
            private ICarBuilder _carBuilder;
            public CarDecorator(ICarBuilder carBuilder)
            {
                _carBuilder = carBuilder;
            }

            public void BuildFrame()
            {
                _carBuilder.BuildFrame();
            }

            public void BuildEngine()
            {
                _carBuilder.BuildEngine();
            }

            public void BuildWheels()
            {
                _carBuilder.BuildWheels();
            }

            public void BuildDoors()
            {
                _carBuilder.BuildDoors();
            }

            public override string ToString()
            {
                return _carBuilder.ToString();
            }
        }
    }
}
