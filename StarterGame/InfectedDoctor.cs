using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class InfectedDoctor :IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Infected Doctor";
        public override string Name { get { return name; } }

        private int attack;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }

        private int dropCount;
        public override int DropCount { get { return dropCount; } }

        private I_Item[] list = { new SutureKit(), new BandAid() };
        private Dictionary<int, I_Item> drops;
        public override Dictionary<int, I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num];
        }
        public override int killValue()
        {
            return 250; 
        }

        public InfectedDoctor()
        {
            attack = 3;
            health = 12;
            hitProbability = 2;
            playerExp = 4;
            dropCount = 1;
            drops = new Dictionary<int, I_Item>();
            for (int i = 0; i < list.Length; i++)
            {
                drops[i] = list[i];
            }
        }
        public override string battleGreeting()
        {
            return "The Infected Doctor is running towards you!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Infected Doctor bites your arm!";
        }
    }
}
