using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public abstract class IEnemy
    {
        //The enemies name 
        public abstract string Name { get; }

        //Attack power of the enemy 
        public abstract int Attack { get; set; }

        //Speed of the enemy
        public abstract int Speed { get; set; }

        //Total health of the enemy 
        public abstract int Health { get; set; }

        //Chance of getting hit by enemy attack
        public abstract int HitProbability { get; }

        //Experience that will be given to the player
        public abstract int PlayerExp { get; set; }

        //Number of items the enemy can drop when they die. 
        public abstract int DropCount { get; }

        //Gives a prompt when the player encounters the enemy
        public abstract string battleGreeting();

        //Displays what happens when the enemy attacks
        public abstract string attackDescription();

        //Provides drops to the room from enemies death
        //params: item number in the Dictionary of available drops of the enemy.  
        public abstract I_Item getDrops(int num);

        //List of available items the enemy can drop. 
        public abstract Dictionary<int, I_Item> Drops { get; }

        public abstract int KillValue { get; set; }
        //public abstract int killValue();

        //Displays the enemies battle stats
        public void currentStats()
        {
            Console.WriteLine("\n" + this.Name + "\nHealth: " + this.Health + "\nAttack: " +
                this.Attack + "\n");
        }

        //For all enemies, method updates the enemies stats relative to the players level to increase
        //difficulty of game as player gets stronger. 
        public void statstoPlayerLevel(int level)
        {
            this.Attack = (int)(level * 1.3) * Attack;
            this.Health = (int)(level * 1.3) * Health;
            this.PlayerExp = (int)(level * 1.3) * PlayerExp;
            this.KillValue = (int)(level * 1.2) * KillValue;
        }

        //provides the room random items at the enemies death based on how many they can drop and what they are capable of dropping
        //param: The current room being given items. 
        public void deadEnemyItems(Room room)
        {
            for (int i = 0; i < DropCount; i++)
            {
                int rand = new Random().Next(0, Drops.Count);
                room.giveItem(getDrops(rand));
            }
            
        }

        //This is the attack action by the rat. It will display the attack description and take away health
        //from the player if the random number is 1.
        public abstract void attackPlayer(Player player);

    }
}
