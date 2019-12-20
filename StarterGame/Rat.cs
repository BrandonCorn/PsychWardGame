using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Rat: IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Rat";
        public override string Name { get { return name;  } }

        private int attack;
        public override int Attack { get { return attack; } set { attack = value; } }

        private int speed;
        public override int Speed { get { return speed; } set { speed = value; } }

        private int health;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp; 
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        private int dropCount;
        public override int DropCount { get { return dropCount; } }

        private I_Item[] itemList = { new RatTail(), new FirstAidKit(), new BandAid() };
        private Dictionary<int, I_Item> drops; 
        public override Dictionary<int,I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num]; 
        }
        private int killValue;
        public override int KillValue { get { return killValue; } set { killValue = value; } }
        /*public override int killValue()
        {
            return 50;
        }*/
        public Rat()
        {
            attack = 3;
            speed = new Random().Next(1, 3);
            health = 12;
            hitProbability = 2;
            playerExp = 4;
            dropCount = 1;
            killValue = 30;
            drops = new Dictionary<int, I_Item>();
            for(int i = 0; i < itemList.Length; i++)
            {
                drops[i] = itemList[i];
            }
        }

        //When the player enters battle they are prompted with this greeting. 
        public override string battleGreeting()
        {
            return "A rabid Rat wants you dead. It lunges at you in fury!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Rat slices your face!";
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
