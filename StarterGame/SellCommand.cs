using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.name = "sell";
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add(CommandType.MerchantCommand, "Merchant sell");
        }

        public override bool execute(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
