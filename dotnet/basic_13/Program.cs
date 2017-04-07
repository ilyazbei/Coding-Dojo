using System;

namespace basic_13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // print_1_to_255(255);
            // Console.WriteLine(" // End of all numbers 1-255");
            // print_odd_1_to_255();
            // printSum_1_255();
            // int[] whatevere = {1,3,5,7,9,13};
            // arrayIterate(whatevere);
            int[] myArr = {-8,-3,10,5,9};
            MaxInArray(myArr);
            AvgOfArray(myArr);
        }
        // Prints values 1 through 255 to the console
        public static void print_1_to_255(int val)
        {
            for(int i = 1; i <= val; i++)
            {
                if(i == val)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i + ", ");

                }
            
            }
            // Console.WriteLine(" // End of all numbers 1-255");
        }
        
        // Print odd numbers between 1-255
        public static void print_odd_1_to_255()
        {
            for(int val = 1; val <= 255; val++)
            {
                if(val % 2 == 1){
                    Console.Write(val + ", ");
                }
            }
            Console.WriteLine("// End of all odd numbers 1-255");
        }  
        // Print Sum all number between 0 and 255
        // New number: $ Sum: #
        public static void printSum_1_255()
        {
            int sum =0;
            for(int num = 0; num <= 255; num++)
            {
                sum += num; // sum = sum + num
                Console.WriteLine($"New Number: {num} Sum: {sum}");
            }
            Console.WriteLine("// End of print sum 1-255");
        }
        // Iterate through a passed array
        public static void arrayIterate(int[] arr) 
        {
            string output = "[";
            for(int idx = 0; idx < arr.Length; idx++)
            {
                output += arr[idx] + ", ";
            }
            output += "]";
            Console.Write(output);
            Console.WriteLine("// End of iterate");

        }

        //Find max value in an array
        public static void MaxInArray(int[] arr)
        {
            int max = arr[0];
            foreach(int val in arr)
            {
                if(val > max)
                {
                    max = val;
                }
            }
            Console.WriteLine("The max value is {0}", max);
        }

        // Get average value of an array
        public static void AvgOfArray(int[] arr)
        {
            int sum = GetSum(arr);
            Console.WriteLine("This average is " + (double)sum/(double)arr.Length);
        }
        public static int GetSum(int[] arr)
        {
            int sum = 0;
            for(int num = 0; num < arr.Length; num++)
            {
                sum += arr[num]; //sum = sum + num
            }
            return sum;
        }

    }

}
