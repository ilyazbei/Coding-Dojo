using System;

namespace basic_13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            print_1_to_255();
            print_odd_1_to_255();
            printSum_1_255();
            int[] whatevere = {1,3,5,7,9,13};
            arrayIterate(whatevere);
        }
        // Prints values 1 through 255 to the console
        public static void print_1_to_255()
        {
            for(int val = 1; val <= 255; val++)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("// End of all numbers 1-255");
        }
        // Print odd numbers between 1-255
        public static void print_odd_1_to_255()
        {
            for(int val = 1; val <= 255; val++)
            {
                if(val % 2 == 1){
                    Console.WriteLine(val);
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
            Console.WriteLine(output);

        }

    }

}
