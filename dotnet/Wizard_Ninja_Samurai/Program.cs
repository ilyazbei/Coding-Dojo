using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Eli = new Human("Eli");
            Wizard MyWizard = new Wizard("Wizard");
            Ninja MyNinja = new Ninja("Ninja");
            Samurai MySamurai1 = new Samurai("Samurai_1");
            Samurai MySamurai2 = new Samurai("Samurai_2");
            Samurai MySamurai3 = new Samurai("Samurai_3");
            MyWizard.Heal();
            System.Console.WriteLine("Eli's current heealt is: " + Eli.health);
            System.Console.WriteLine("Samurai's current heealt is: " + MySamurai1.health);
            // MyWizard.Fireball(Eli);
            // MyNinja.Steal(Eli);
            // MyNinja.GetAway();
            MySamurai2.attack(Eli);
            MySamurai3.attack(Eli);
            MySamurai1.attack(Eli);
            MySamurai1.attack(Eli);
            Eli.attack(MySamurai1);
            MySamurai1.DeathBlow(Eli);
            System.Console.WriteLine("Samurai attacked Eli");
            System.Console.WriteLine("And now Eli's current heealt is: " + Eli.health);
            System.Console.WriteLine("And now Samurai's current heealt is: " + MySamurai1.health);
            MySamurai1.Meditate();

            System.Console.WriteLine("And now Samurai's current heealt is: " + MySamurai1.health);

            Samurai.HowMany();


        }
    }
}
