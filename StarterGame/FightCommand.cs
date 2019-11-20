using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class FightCommand : Command
    {
        public FightCommand() : base()
        {
            this.name = "fight";
            
        }
        //If the player fights the enemy, if they kill the enemy then this returns false to exit the 
        //battle sequence in the GameWorld, otherwise it remains true. 
        public override bool execute(Player player)
        {
            IEnemy enemy = player.currentRoom.CurrentEnemy;
            player.useWeapon();
            //if (player.currentRoom.CurrentEnemy.Health <= 0)
            if (enemy.Health <= 0)
            {
                player.outputMessage("\nYou win!!!\n");
                NotificationCenter.Instance.postNotification(new Notification("PopCommands", this));
                NotificationCenter.Instance.postNotification(new Notification("BattleOver", this));
                //player.CurrentEnemy = null;
                player.currentRoom.CurrentEnemy = null; 
                return false;
            }
            else {
                //player.CurrentEnemy.attackPlayer(player);
                enemy.attackPlayer(player);
            }

            if(player.Health <= 0)
            {
                player.outputMessage("You died");
                return true;
            }
            player.currentStats();
            //player.CurrentEnemy.currentStats();
            enemy.currentStats();
            return false;
        }
    }
}
