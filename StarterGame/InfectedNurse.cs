using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class InfectedNurse: IEnemy
    {
        private readonly string name = "Infected Nurse";
        public override string Name { get { return name; } }

        private int attack = 3;
        public override int Attack { get { return attack; } set { attack = value; } }
        private int health = 12;
        public override int Health { get { return health; } set { health = value; } }

        private int hitProbability = 2;
        public override int HitProbability { get { return hitProbability; } }

        private int playerExp = 4;
        public override int PlayerExp { get { return playerExp; } set { playerExp = value; } }
        private I_Item drops = new FirstAidKit();
        public override I_Item getDrops()
        {
            return new FirstAidKit();
        }
        public override int killValue()
        {
            return 100;
        }
        public InfectedNurse()
        {

        }
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
    }
}
