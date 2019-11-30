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
        public override bool execute(Player player)
        {
            string notify = "PlayerSpeak_";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nSpeak to who?");
                return false; 
            }
            else
            {
                while (this.Words.Count != 0)
                {
                    notify += this.Words.Dequeue();
                }
                NotificationCenter.Instance.postNotification(new Notification("SpokeToMerchant", player));
                NotificationCenter.Instance.postNotification(new Notification(notify, player));
                player.outputMessage("\nType \"walk away\" to end the interaction");
            }
            return false; 
        }
    }
}
