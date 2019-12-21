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

        public override bool execute(Player player)
        {
            NotificationCenter.Instance.postNotification(new Notification("ViewInventory", this));
            return false; 
        }
    }
}
