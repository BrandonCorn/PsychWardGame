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

        public override bool execute(Player player)
        {
            if (player.InBattle)
            {
                Console.WriteLine("This is a test, the fight sequence is working.");
            }
            return true;
        }
    }
}
