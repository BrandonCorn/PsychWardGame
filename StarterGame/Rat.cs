using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Rat: IEnemy
    {
        private readonly string name = "Rat";
        public override string Name { get { return name;  } }
        private readonly EnemyType enemyType = EnemyType.Rat;
        public override EnemyType EnemyType { get { return enemyType; } }
        private int level; 
        public override int Level { get { return level; } }
        private int attack;
        public override int Attack { get { return attack; } }
        private int health;
        public override int Health { get { return health; } set { health = value; } }
        private int hitProbability;
        public override int HitProbability { get { return hitProbability; } }
        public Rat()
        {
            level = 1;
            attack = 3;
            health = 12; 
            hitProbability = 3;
        }
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
        //This is the attack action by the rat. It will display the attack description and take away health
        //from the player if the random number is 1. This approach for random chance is written slightly
        //different than the chance to enter battle as it only uses one random number and assumes 1 is always
        //an option. 
        public override void attackPlayer(Player player)
        {
            int chance = new Random().Next(1, HitProbability + 1);
            if (chance == 1 && this.Health > 0)
            {
                Console.WriteLine(attackDescription());
                player.Health -= new Random().Next(1, Attack + 1);
            }
        }

        public override void EnemyRespondAttack(Notification notification)
        {
            Player player = (Player)notification.Object;
            int chance = new Random().Next(1, HitProbability + 1);
            if (chance == 1 && this.Health > 0)
            {
                Console.WriteLine(attackDescription());
                player.Health -= new Random().Next(1, Attack + 1);
            }
        }

        public override void currentStats()
        {
            Console.WriteLine("\n" + this.Name + "\nHealth: " + this.Health + "\nAttack: " + 
                this.Attack + "\n");
        }
    }
}
