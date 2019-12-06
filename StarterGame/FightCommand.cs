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
            if (enemy.Health <= 0)
            {
                player.outputMessage("\nYou win!!!\n");
                NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
                NotificationCenter.Instance.postNotification(new Notification("BattleOver", player));
                NotificationCenter.Instance.postNotification(new Notification("KilledEnemies", player));
                if (enemy.GetType() == typeof(FinalBoss))
                {
                    player.outputMessage("You Beat the Game");
                    return true;
                }
                player.outputMessage("\n" + player.currentRoom.description());
                return false;
            }
            else {
                enemy.attackPlayer(player);
            }

            if(player.Health <= 0)
            {
                player.outputMessage("You died");
                return true;
            }
            player.currentStats();
            enemy.currentStats();
            return false;
        }
    }
}
