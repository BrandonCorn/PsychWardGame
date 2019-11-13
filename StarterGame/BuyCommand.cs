using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class BuyCommand : Command
    {
        
        public BuyCommand()
        {
            this.name = "buy";
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add(CommandType.MerchantCommand, "Merchan Buy Command");
        }
        public override bool execute(Player player)
        {
            return true;
        }
    }
}
