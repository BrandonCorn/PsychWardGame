using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BackCommand : Command
    {

        public BackCommand()
        {
            this.name = "back";
        }

        /**
        * Pops commands from players current situation. 
        * @params: (Player) current player of the game. 
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            NotificationCenter.Instance.postNotification(new Notification("PopCommands"));
            //player.outputMessage(player.currentRoom.description());
            return false;
        }
    }
}
