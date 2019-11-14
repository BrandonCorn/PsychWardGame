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
            //this.CommandTypes = new Dictionary<CommandType,string>();
            //CommandTypes.Add(CommandType.BattleCommand,"Fight Battle Command");
            
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
                player.outputMessage(player.currentRoom.description());
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
