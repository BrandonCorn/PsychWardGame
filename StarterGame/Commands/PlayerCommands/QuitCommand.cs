using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class QuitCommand : Command
    {

        public QuitCommand() : base()
        {
            this.name = "quit";
            
        }

        /**
        * Command that allows player to quit the game.   
        * @params: (Player) current player of the game.  
        * @return: (bool) true/false value whether game is over or not. 
        **/
        override
        public bool execute(Player player)
        {
            bool answer = true;
            if (this.Words.Count > 0)
            {
                player.outputMessage("\nI cannot quit that");
                answer = false;
            }
            return answer;
        }
    }
}
