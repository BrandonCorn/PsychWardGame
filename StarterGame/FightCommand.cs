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
            player.useWeapon();
            if (player.CurrentEnemy.Health <= 0)
            {
                player.outputMessage("\nYou win!!!\n");
                NotificationCenter.Instance.postNotification(new Notification("PopCommands", this));
                NotificationCenter.Instance.postNotification(new Notification("BattleOver", this));
                
                return false;
            }
            else {
                player.CurrentEnemy.attackPlayer(player);
            }

            if(player.Health <= 0)
            {
                player.outputMessage("You died");
                return true;
            }
            player.currentStats();
            player.CurrentEnemy.currentStats();
            return false;
        }
    }
}
