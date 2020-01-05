using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    public class SpeakCommand : Command
    {
        public SpeakCommand()
        {
            this.name = "speak";
        }

        /**
         * Command called by the current player to intiate speaking.  
         * @params: (Player) current player of the game speaking. 
         * @return: (bool) true/false value whether game is over or not. 
         **/
        public override bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.speak(this.secondWord);
            }
            else
            {
                player.outputMessage("\nSpeak What");
            }
            return false;
        }
    }
}
