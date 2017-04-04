using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles
{
    public class Program
    {

        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array, Print the sum of all the values
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randArr = new int[10];
            int sum = 0;
            for(int i = 0; i < randArr.Length; i++)
            {
                // Up to 26 since .Next is non-inclusive
                int val = rand.Next(5,26);
                randArr[i] = val;
                sum += val; // sum = sum + val
                Console.WriteLine(val);
            }
            Console.WriteLine("The max value of the random array is {0}", randArr.Max());
            Console.WriteLine("The min value of the random array is {0}", randArr.Min());
            Console.WriteLine("The sum value of the random array is {0}", randArr.Sum());
            return randArr;
        }
        // Coin Flip
        public static string TossCoin(Random rand)
        {
            Console.WriteLine("Tossing a Coin");
            string heads = "Heads";
            string tails = "Tails";
            int result = rand.Next(0,2);
            if(result == 1)
            {
                Console.WriteLine(tails);
                return tails;
            } 
            else 
            {
                Console.WriteLine(heads);
                return heads;
            }
            
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();
            RandomArray();
            TossCoin(rand);
        }        

    }
}
