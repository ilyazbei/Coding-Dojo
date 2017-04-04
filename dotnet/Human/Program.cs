using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Eli = new Human("Elias");
            Human Dylan = new Human("Dylan");
            Console.WriteLine("Dylons current health is at: " + Dylan.health + "%");
            // Eli.Attack(Dylan);
            Console.WriteLine("Eli gone crazy and attacked Dylon with super combo of five palm punch");
            Eli.Attack(Dylan);
            Console.WriteLine("Dylons helth drop singificantly and current helt is at: " + Dylan.health + "%");
            
        }
    }
}


