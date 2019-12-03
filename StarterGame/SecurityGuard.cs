using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SecurityGuard : IEnemy
    {
        //VIEW IENEMY INTERFACE FOR DESCRIPTIONS OF VARIABLES AND PROPERTIES

        private readonly string name = "Security Guard";
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
 
        private I_Item[] list = { new LockPick(), new SutureKit(), new BandAid() };
        private Dictionary<int, I_Item> drops;
        public override Dictionary<int, I_Item> Drops { get { return drops; } }
        public override I_Item getDrops(int num)
        {
            return Drops[num];
        }
        public override int killValue()
        {
            return 200;
        }
        public SecurityGuard()
        {
            attack = 3;
            health = 12;
            hitProbability = 2;
            playerExp = 4;
            dropCount = 1;
        }
        public override string battleGreeting()
        {
            return "The psycho security guard is running at you with his batton!";
        }

        //Description of the Rat attacking the player to display. We can write more these in this method
        //and make it so that random ones display each time. 
        public override string attackDescription()
        {
            return "\nThe Security Guard swings at you!";
        }
    }
}
