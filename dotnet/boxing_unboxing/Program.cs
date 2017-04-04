using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> myList = new List<object>();

            // Add the following values to the list: 7, 28, -1, true, "chair"
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            //Loop through the list, display all values and Add all values that are Int type together and output the sum
            int sum = 0;
            foreach(var obj in myList) {
                Console.WriteLine(obj);
                if(obj is int) {
                    sum += (int)obj;
                }
            }
            Console.WriteLine("The sum of all the integers in the list is {0}", sum);
        }
    }
}
