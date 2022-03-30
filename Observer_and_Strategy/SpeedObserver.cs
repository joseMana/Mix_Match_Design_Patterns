namespace ObserverPattern
{
    public class SpeedObserver : IObserver
    {
        private Vehicle _vehicle;
        private ISpeedBehavior _speedBehavior;

        public SpeedObserver(Vehicle vehicle, ISpeedBehavior speedBehavior)
        {
            _vehicle = vehicle;
            _speedBehavior = speedBehavior;
            _vehicle.Attach(this);
        }
        public SpeedObserver(Vehicle vehicle)
        {
            _vehicle = vehicle;
            _speedBehavior = vehicle.SpeedBehavior;
            _vehicle.Attach(this);
        }

        public void Update()
        {
            if (_vehicle.Speed > 80)
            {
                _speedBehavior.SpeedUp();
            }
            else
            {
                _speedBehavior.SlowDown();
            }
        }
    }
}
