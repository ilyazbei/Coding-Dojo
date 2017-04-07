using System;

namespace oop_with_C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Vehicle(2);
            Vehicle myBike = new Vehicle(1);
            Console.WriteLine("Car has " + myCar.numPassenger + " passengers");
            Console.WriteLine("Bike has " + myBike.numPassenger + " passenger");
            myBike.Move(1.3);
            myCar.Move(4.5);
            Console.WriteLine("My Bike went {0} miles & my car went {1} miles", myBike.distance, myCar.distance);
        }
    }
}
