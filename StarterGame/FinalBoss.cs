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
        public override int PlayerExp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FinalBoss()
        {
            attack = 30;
            health = 1000;
            hitProbability = 3;
            playerExp = 2500;
        }
        public override string attackDescription()
        {
            throw new NotImplementedException();
        }

        public override string battleGreeting()
        {
            throw new NotImplementedException();
        }

        public override I_Item getDrops()
        {
            throw new NotImplementedException();
        }

        public override int killValue()
        {
            throw new NotImplementedException();
        }

    }
}
