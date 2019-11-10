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
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add(CommandType.BattleCommand,"Fight Battle Command");
            
        }
        //If the player fights the enemy, if they kill the enemy then this returns false to exit the 
        //battle sequence in the GameWorld, otherwise it remains true. 
        public override bool execute(Player player)
        {
            if (player.InBattle)
            {
                player.useWeapon();
            }
            if (player.CurrentEnemy.Health <= 0)
            {
                player.outputMessage("\nYou win!!!\n");
                return false;
            }
            return true;
        }
    }
}
