using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class InfectedNurse : IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Infected Nurse";
        public override string Name { get { return name; } }

        private int attack;
        public override int Attack { get { return attack; } set { attack = value; } }

        private int speed;
        public override int Speed {get {return speed; } set { speed = value; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        private int dropCount;
        public override int DropCount { get { return dropCount; } }

        private I_Item[] list = { new RatTail(), new FirstAidKit(), new BandAid() };
        private Dictionary<int, I_Item> drops;
        public override Dictionary<int, I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num];
        }
        private int killValue;
        public override int KillValue { get { return killValue; } set { killValue = value; } }

        public InfectedNurse()
        {
            attack = 3;
            speed = new Random().Next(1, 4);
            health = 13;
            hitProbability = 2;
            playerExp = 5;
            dropCount = 1;
            killValue = 40;
            drops = new Dictionary<int, I_Item>();
            for (int i = 0; i < list.Length; i++)
            {
                drops[i] = list[i];
            }
        }

        //When the player enters battle they are prompted with this greeting. 
        public override string battleGreeting()
        {
            return "The Infected Nurse is coming at you!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Infected Nurse stabs you with a nasty syringe!";
        }

        public override void attackPlayer(Player player)
        {
            int chance = new Random().Next(1, HitProbability + 1);
            if (chance == 1 && this.Health > 0)
            {
                Console.WriteLine("\n" + attackDescription() + "\n");
                player.Health -= new Random().Next((Attack / 2), Attack + 1);
            }
            else { Console.WriteLine("\n" + Name + " missed the attack\n"); }

        }
    }
}
