namespace Wizard_Ninja_Samurai
{
    public class Ninja: Human
    {
        public Ninja(string ninja) : base(ninja)
        {
            dexterity = 175;  
        }

        public void Steal(object target)
        {
            Human enemy = target as Human;
            if(enemy != null)
            {
                attack(enemy);
                health += 10;
            }
        }

        public void GetAway(object target)
        { 
            health -= 5;  
        }
    }
}