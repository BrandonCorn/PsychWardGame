using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public abstract class IEnemy
    {
        public abstract string Name { get; }
        public abstract EnemyType EnemyType {get;}
        public abstract int Level { get; }
        public abstract int Attack { get; }
        public abstract int Health { get; set; }
        //Chance of getting hit by enemy attack
        public abstract int HitProbability { get; }
        //Gives a prompt when the player encounters the enemy
        public abstract string battleGreeting();
        //Displays what happens when the enemy attacks
        public abstract string attackDescription();
        //The action of an enemy attacking the player
        public abstract void attackPlayer(Player player);
        //Displays the enemies battle stats
        public abstract void currentStats();

        public IEnemy()
        {
            NotificationCenter.Instance.addObserver("EnemyRespondAttack", EnemyRespondAttack);
        }

        public abstract void EnemyRespondAttack(Notification notification);
    }
}
