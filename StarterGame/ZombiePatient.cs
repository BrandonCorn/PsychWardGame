using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class ZombiePatient :IEnemy
    {
        public readonly EnemyType enemyType = EnemyType.ZombiePatient; 
        public EnemyType EnemyType { get { return enemyType; } }
        private int level; 
        public int Level { get { return level; } }
        private int attack;
        public int Attack { get { return attack; } }
        private int health;
        public int Health { get { return health; } }
        private float hitProbability;
        public float HitProbability { get { return hitProbability; } }
        public string battleGreeting()
        {
            return "A mummified zombie patient blindsides you out of no where!";
        }
        public string AttackDescription ()
        {
            return "";
        }
        
        public ZombiePatient()
        {
            level = 1;
            attack = 4;
            health = 14;
            hitProbability = 1 / 3;
        }
    }
}
