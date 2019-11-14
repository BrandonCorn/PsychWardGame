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
            this.CommandTypes = new Dictionary<CommandType, string>();
            //CommandTypes.Add(CommandType.BasicCommand, "Interact Basic Command");
            //CommandTypes.Add(CommandType.MerchantCommand, "Interact Merchant Command");
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
                NotificationCenter.Instance.postNotification(new Notification(notify, player));
            }
            return false; 
        }
    }
}
