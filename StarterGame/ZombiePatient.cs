using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class ZombiePatient :IEnemy
    {
        private readonly string name = "Zombie Patient";
        public override string Name { get { return name; } }

        private int level; 
        public override int Level { get { return level; } }
        private int attack;
        public override int Attack { get { return attack; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }
        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }
        
        public ZombiePatient()
        {
            level = 1;
            attack = 4;
            health = 14;
            hitProbability = 2;
        }

        //
        public override string battleGreeting()
        {
            return "A mummified zombie patient blindsides you out of no where!";
        }

        //Description of the enemy attacking the player
        public override string attackDescription()
        {
            return "\nThe Zombie leaps forward and bites you!";
        }

        //As long as the enemy has health and the enemies attack hitting are true the enemy will attack
        //the player
        public override void attackPlayer(Player player)
        {
            int chance = new Random().Next(1, HitProbability + 1);
            if (chance == 1 && this.Health > 0)
            {
                Console.WriteLine("\n" + attackDescription()+"\n");
                player.Health -= new Random().Next(1, Attack + 1);
            }
            else { Console.WriteLine("\n" + Name + " missed the attack\n"); }
        }

        public override void currentStats()
        {
            Console.WriteLine("\n" + this.Name + "\nHealth: " + this.Health + "\nAttack: " + 
                this.Attack + "\n");
        }
    }
}
