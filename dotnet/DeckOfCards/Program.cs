using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Let's play some BlackJack!");
            Deck MyDeck = new Deck();
            MyDeck.Shuffle();
            Player Eli = new Player("Eli");

            Eli.Draw(MyDeck);
            Eli.Draw(MyDeck);
            Eli.Draw(MyDeck);
            Eli.Draw(MyDeck);
            Eli.Draw(MyDeck);
            Console.WriteLine(Eli.Hand);

            Eli.Discard(6);

            Console.WriteLine(Eli.Hand);

            // Player Ivan = new Player("Ivan");
            
            // Console.WriteLine(MyDeck);

            // Eli.Draw(MyDeck);
            // Eli.Draw(MyDeck);
            // Ivan.Draw(MyDeck);
            // Ivan.Draw(MyDeck);

            // Console.WriteLine(Eli.Name);
            // Console.WriteLine(Eli.Hand);
            // Console.WriteLine(Ivan.Hand);
            // // System.Console.WriteLine(MyDeck);
            // Card DealtCard = MyDeck.Deal();
            // Card DealtCard1 = MyDeck.Deal();
            // Card DealtCard2 = MyDeck.Deal();
            // Card DealtCard3 = MyDeck.Deal();
            // Card DealtCard4 = MyDeck.Deal();
            // // System.Console.WriteLine(DealtCard);
            // System.Console.WriteLine(MyDeck);
            // MyDeck.Reset();
            // System.Console.WriteLine(MyDeck);
            // MyDeck.Shuffle();
            // System.Console.WriteLine(MyDeck);
            
        }
    }
}
