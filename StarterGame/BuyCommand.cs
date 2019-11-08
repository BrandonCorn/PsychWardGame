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
            this.CommandType = CommandType.MerchantCommand;
        }
        public override bool execute(Player player)
        {
            return true;
        }
    }
}
