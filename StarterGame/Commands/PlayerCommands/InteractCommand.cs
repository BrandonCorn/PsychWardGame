using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class InteractCommand : Command
    {

        public InteractCommand()
        {
            this.name = "interact";
        }

        /**
         * Initiates an interaction between the player and an NPC.   
         * @params: (Player) current player of the game speaking. 
         * @return: (bool) true/false value whether game is over or not. 
         **/
        public override bool execute(Player player)
        {
            string notify = "PlayerSpeak_";
            string name = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nSpeak to who?");
                return false; 
            }
            else
            {
                while (this.Words.Count != 0)
                {
                    name += this.Words.Dequeue() + " ";
                }
                
                name = name.TrimEnd();
                notify += name;
                INPC npc = player.currentRoom.getNPC(name);
                if (npc != null)
                {
                    NotificationCenter.Instance.postNotification(new Notification(notify, player));
                    NotificationCenter.Instance.postNotification(new Notification("FirstMerchantInteraction", this));
                    player.outputMessage("\nType \"walk away\" to end the interaction");
                }
                else
                {
                    player.outputMessage("\nThat person is not in this room?\n");
                    player.outputMessage(player.currentRoom.description());
                }
            }
            return false; 
        }
    }
}
