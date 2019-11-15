using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class LeaveCommand : Command
    {

        public LeaveCommand()
        {
            this.name = "leave"; 
            
        }


        public override bool execute(Player player)
        {
            
            NotificationCenter.Instance.postNotification(new Notification("PopCommands",this));
            NotificationCenter.Instance.postNotification(new Notification("LeaveMerchant", this));
            player.outputMessage("\n" + player.currentRoom.description());
            return false; 
        }
    }
}
