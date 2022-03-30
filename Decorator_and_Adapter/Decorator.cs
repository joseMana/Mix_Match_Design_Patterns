namespace Decorator_and_Adapter
{
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
}
