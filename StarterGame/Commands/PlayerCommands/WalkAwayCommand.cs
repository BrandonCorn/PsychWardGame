using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class WalkAwayCommand : Command
    {

        public WalkAwayCommand()
        {
            this.name = "walk away"; 
            
        }

        /**
        * Command that tells player to end interaction with NPC/merchant.  
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            
            NotificationCenter.Instance.postNotification(new Notification("PopCommands",this));
            NotificationCenter.Instance.postNotification(new Notification("LeaveMerchant", this));
            player.outputMessage("\n" + player.currentRoom.description());
            return false; 
        }
    }
}
