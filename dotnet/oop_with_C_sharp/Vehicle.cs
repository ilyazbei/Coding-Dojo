namespace oop_with_C_sharp
{
    public class Vehicle
    {
        public int numPassenger;
        public double distance;

        public Vehicle(int val = 0)
        {
            numPassenger = val;
            distance = 0.0;
        }

        public void Move(double miles)
        {
            distance += miles;
        }
    }
}