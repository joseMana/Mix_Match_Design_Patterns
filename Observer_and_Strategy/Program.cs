using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeedBehavior mySpeedBehavior = new SpeedBehavior();

            Vehicle myVehicle = new Vehicle(mySpeedBehavior);

            SpeedObserver mySpeedObserver = new SpeedObserver(myVehicle);

            #region Change speed

            //change the vehicle's speed to 10
            myVehicle.Speed = 10;

            //change the vehicle's speed to 15
            myVehicle.Speed = 15;

            //change the vehicle's speed to 20
            myVehicle.Speed = 20;

            //change the vehicle's speed to 25
            myVehicle.Speed = 25;

            //change the vehicle's speed to 30
            myVehicle.Speed = 30;

            //change the vehicle's speed to 35
            myVehicle.Speed = 35;

            //change the vehicle's speed to 40
            myVehicle.Speed = 40;

            //change the vehicle's speed to 45
            myVehicle.Speed = 45;

            //change the vehicle's speed to 50
            myVehicle.Speed = 50;

            //change the vehicle's speed to 55
            myVehicle.Speed = 55;

            //change the vehicle's speed to 60
            myVehicle.Speed = 60;

            //change the vehicle's speed to 65
            myVehicle.Speed = 65;

            //change the vehicle's speed to 70
            myVehicle.Speed = 70;

            //change the vehicle's speed to 75
            myVehicle.Speed = 75;

            //change the vehicle's speed to 80
            myVehicle.Speed = 80;

            //change the vehicle's speed to 85
            myVehicle.Speed = 85;

            //change the vehicle's speed to 90
            myVehicle.Speed = 90;

            //change the vehicle's speed to 95
            myVehicle.Speed = 95;
            #endregion

            Console.ReadLine();
        }
    }
}
