using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class UseCommand : Command
    {
        public UseCommand()
        {
            this.name = "use";
        }

        public override bool execute(Player player)
        {
            //In this method will write how a player will use an item they have in their bag. 
            return false;
        }
    }
}
