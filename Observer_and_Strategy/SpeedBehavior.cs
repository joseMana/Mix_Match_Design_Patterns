using System;

namespace ObserverPattern
{
    public class SpeedBehavior : ISpeedBehavior
    {
        public void SpeedUp()
        {
            Console.WriteLine("Vehicle is speeding up");
        }

        public void SlowDown()
        {
            Console.WriteLine("Vehicle is slowing down");
        }
    }
}
