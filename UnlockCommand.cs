using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class UnlockCommand:Command
    {
        public UnlockCommand() : base()
        {
            this.name = "Unlock";
            
        }
        public override bool execute(Player player)
        {
            string location = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nThis door is now unlocked. ");
                return false;
            }
            while (this.Words.Count > 0)
            {
                if (this.Words.Count == 1)
                {
                    location += this.Words.Dequeue();
                }
                else
                {
                    location += this.Words.Dequeue() + " ";
                }
            }
            player.waltTo(location);
            return false;
        }
    }
}
