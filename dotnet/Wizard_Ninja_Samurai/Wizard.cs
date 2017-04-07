using System;

namespace Wizard_Ninja_Samurai
{
    public class Wizard: Human
    {
        public Wizard(string wizard) : base(wizard)
        {
            health = 50;
            intelligence = 50;
        }

        // Method
        public void Heal()
        {
            health += 10 * intelligence;
        }

        public void Fireball(object target)
        {
            Human enemy = target as Human;
            if(enemy != null)
            {
                Random rand = new Random();
                enemy.health -= rand.Next(20, 51);
            }
        }
    }
}