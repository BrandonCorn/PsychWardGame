using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class BackpackCommand : Command
    {

        public BackpackCommand()
        {
            this.name = "backpack";
        }

        /**
        * Player opens their backpack to interact with it for things such as using items or viewing inventory. 
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            if (player.Backpack != null)
            {
                NotificationCenter.Instance.postNotification(new Notification("PushBackpackCommands", this));
                player.outputMessage("\n****************************************************");
                player.outputMessage("\nCoins: " + player.Coins);
                player.outputMessage(player.Backpack.displayItems() +
                    "\nType \"back\" to close the backpack");
                return false;
            }
            else
            {
                player.outputMessage("I have no backpack!");
                player.outputMessage(player.currentRoom.description());
                return false;
            }
        }
    }
}
