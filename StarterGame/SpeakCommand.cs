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
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add(CommandType.BasicCommand, "Speak Basic Command" );
        }

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
