using System;

namespace Vehicle
{
    public class Vehicle
    {
        public int NumPassengers { get; set; }
        public double Distance { get; set; }
        //Constructors can be overloaded 
        //The first maybe being for a new vehicle
        public Vehicle(int val)
        {
            NumPassengers = val;
                Distance = 0.0;
        }
        //The second for preowned with milage already
        public Vehicle(int val, double odo)
        {
            NumPassengers = val;
            Distance = odo;
        }
        //Method can also be overloaded for handling different parameters
        public int Move(double miles)
        {
            Distance += miles;
            return (int)Distance;
        }
        //If a boolean is included in this version of the method call
        //it may be measuring in km rather than miles.
        public int Move(double miles, bool km)
        {
            //Convert the KM measurement to miles
            if (km == true)
            {
                miles = miles * 0.62;
            }
            Distance += miles;
            return (int)Distance;
        }
    }    
}