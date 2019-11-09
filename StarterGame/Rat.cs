using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class Rat: IEnemy
    {
        private readonly EnemyType enemyType = EnemyType.Rat;
        public EnemyType EnemyType { get { return enemyType; } }
        private int level; 
        public int Level { get { return level; } }
        private int attack;
        public int Attack { get { return attack; } }
        private int health;
        public int Health { get { return health; } }
        private float hitProbability;
        public float HitProbability { get { return hitProbability; } }
        public String battleGreeting()
        {
            return "A rabid Rat wants you dead. It lunges at you in fury!"; 
        }
        public String AttackDescription()
        {
            return ""; 
        }

        public Rat()
        {
            level = 1;
            attack = 3;
            health = 12; 
            hitProbability = 1 / 3;
        }
    }
}
