namespace Wizard_Ninja_Samurai
{
    public class Samurai: Human
    {
        public static int count = 0;
        public Samurai(string samurai) : base(samurai)
        {
            count++;
            health = 200;
        }
        
        public void DeathBlow(object target)
        {
            Human enemy = target as Human;
            if(enemy != null)
            {
                if( enemy.health < 50 )
                {
                    enemy.health = 0;
                    System.Console.WriteLine("You have been attacked by Samurai with his soecial Death Blow! ");
                }
            }
        }

        public void Meditate()
        {
            health = 200;
            System.Console.WriteLine("Samurai used his special ability Meditation which healed his health back to full");
        }

        public static void HowMany()
        {
            System.Console.WriteLine("Currently there is " + count + " invisible Ninjas in your room, be carefull my friend");
        }

    }
}