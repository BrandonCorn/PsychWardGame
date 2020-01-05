using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class MerchandiseCommand : Command
    {
        public MerchandiseCommand()
        {
            this.name = "merchandise"; 
        }

        /**
        * Command that notifies the merchant to display their inventory.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            NotificationCenter.Instance.postNotification(new Notification("ViewInventory"));
            return false; 
        }
    }
}
