using System.Collections.Generic;

namespace ObserverPattern
{
    public class Vehicle
    {
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                Notify();
            }
        }
        public ISpeedBehavior SpeedBehavior { get; set; }
        private List<IObserver> _observers = new List<IObserver>();
        public Vehicle(ISpeedBehavior speedBehavior)
        {
            SpeedBehavior = speedBehavior;
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
