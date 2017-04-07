using System;

namespace cs_fund_1
{
    class Program
    {
        static void Main()
        {
            count_to_255();
            threes_and_fives();
            fizz_and_buzz();
            no_module_fizz_and_buzz();
            rand();
        }

        public static void count_to_255()
        {
            for ( int i = 1; i <= 255; i++ )
            {
                Console.WriteLine( i );
            }
        }

        public static void threes_and_fives()
        {
            for ( int i = 1; i <= 100; i++ )
            {
                if ( i % 3 == 0 && i % 5 == 0)
                {

                }
                else if ( i % 3 == 0 )
                {
                    Console.WriteLine( i );
                }
                else if ( i % 5 == 0 )
                {
                    Console.WriteLine( i );
                }
            }
        }

        public static void fizz_and_buzz()
        {
            for ( int i = 1; i <= 100; i++ )
            {
                if ( i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuszz");
                }
                else if ( i % 3 == 0 )
                {
                    Console.WriteLine("Fizz");
                }
                else if ( i % 5 == 0 )
                {
                    Console.WriteLine("Buzz");
                }
            }
        }

        public static void no_module_fizz_and_buzz()
        {
            int Three = 3;
            int Five = 5;
            for ( int i = 1; i <= 100; i++ )
            {
                Three --;
                Five --;
                if ( Three == 0 && Five == 0 )
                {
                    Console.WriteLine("FizzBuszz");
                    Three = 3;
                    Five = 5;
                }
                else if ( Three == 0 )
                {
                    Console.WriteLine("Fizz");
                    Three = 3;
                }
                else if ( Five == 0 )
                {
                    Console.WriteLine("Buzz");
                    Five = 5;
                }
            }
        }

        public static void rand()
        {
            Random randNumbersss = new Random();
            for ( int i = 1; i <= 10; i++ )
            {
                Console.WriteLine("Your count is: " + i + ", Your random number is: " + randNumbersss.Next(1, 101));
            }
        }
    }
}
