using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class GoCommand : Command
    {

        public GoCommand() : base()
        {
            this.name = "go";
        }

        /**
        * Command that initiates a player walking to a different room. 
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        public override bool execute(Player player)
        {
            string location = "";
            if (this.Words.Count == 0)
            {
                player.outputMessage("\nGo Where?");
                return false;
            }
            while (this.Words.Count > 0)
            {
                location += this.Words.Dequeue() + " ";
            }
            location = location.TrimEnd();
            player.waltTo(location);
            return false;
        } 
    }
}
