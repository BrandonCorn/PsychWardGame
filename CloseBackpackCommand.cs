using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class CloseBackpackCommand : Command
    {

        public CloseBackpackCommand()
        {
            this.name = "close backpack";
        }
        public override bool execute(Player player)
        {
            NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
            player.outputMessage(player.currentRoom.description());
            return false;
        }
    }
}
