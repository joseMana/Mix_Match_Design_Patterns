using System;
using System.Collections.Generic;

namespace Mediator_and_Singleton
{
    //create a class that uses a Mediator pattern that uses a Singleton pattern to provide a centralized point of communication between objects.

    //This is the mediator interface
    public interface IMediator
    {
        void Register(string name, IColleague colleague);
        void Send(string name, string message);
    }

    //This is the colleague interface
    public interface IColleague
    {
        void Receive(string from, string message);
    }

    //This is the concrete colleague class
    public class Colleague : IColleague
    {
        private string _name;
        private IMediator _mediator;

        public Colleague(string name, IMediator mediator)
        {
            _name = name;
            _mediator = mediator;
        }

        public void Send(string to, string message)
        {
            _mediator.Send(to, message);
        }

        public void Receive(string from, string message)
        {
            Console.WriteLine("{0} received {1} from {2}", _name, message, from);
        }
    }

    //This is the concrete mediator class
    public class Mediator : IMediator
    {
        private static Mediator _instance;
        private Dictionary<string, IColleague> _colleagues = new Dictionary<string, IColleague>();

        private Mediator() { }

        public static Mediator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Mediator();
            }
            return _instance;
        }

        public void Register(string name, IColleague colleague)
        {
            _colleagues.Add(name, colleague);
        }

        public void Send(string name, string message)
        {
            _colleagues[name].Receive(name, message);
        }
    }

    //This is the client
    public class Client
    {
        static void Main(string[] args)
        {
            Mediator mediator = Mediator.GetInstance();

            Colleague colleague1 = new Colleague("Colleague 1", mediator);
            Colleague colleague2 = new Colleague("Colleague 2", mediator);
            Colleague colleague3 = new Colleague("Colleague 3", mediator);

            mediator.Register("Colleague 1", colleague1);
            mediator.Register("Colleague 2", colleague2);
            mediator.Register("Colleague 3", colleague3);

            colleague1.Send("Colleague 2", "Hello");
            colleague2.Send("Colleague 3", "Hello");
            colleague3.Send("Colleague 1", "Hello");

            Console.ReadKey();
        }
    }
}
