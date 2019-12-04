using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class FinalBoss : IEnemy
    {
        private readonly string name = "Final Boss";
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

        private I_Item[] itemList = { new FirstAidKit(), new BandAid(), new SutureKit() };
        private Dictionary<int, I_Item> drops; 
        public override Dictionary<int, I_Item> Drops => throw new NotImplementedException();

        public FinalBoss()
        {
            attack = 30;
            health = 1000;
            hitProbability = 3;
            playerExp = 2500;
            dropCount = 3;
            drops = new Dictionary<int, I_Item>();
            for (int i = 0; i < itemList.Length; i++)
            {
                drops[i] = itemList[i];
            }
        }
        public override string attackDescription()
        {
            return "The luny mummy man flails his arms at you in craziness!"; 
        }

        public override string battleGreeting()
        {
            return "The final battle begins";
        }

        public override int killValue()
        {
            return 1000;
        }

        public override I_Item getDrops(int num)
        {
            return Drops[num];
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
