using System;

namespace Human
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string str)
        {
            name = str;
        }
        
        public Human(string nm, int str, int intel, int dex, int hlth)
        {
            name = nm;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hlth;
        }

        public void Attack(object human)
        {
            Human target = human as Human;
            if(target != null)
            {
                target.health -= strength * 5;
                // Console.WriteLine(target.health);
            }
        }
    }
}

