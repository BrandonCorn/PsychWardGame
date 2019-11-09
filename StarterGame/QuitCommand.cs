using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class QuitCommand : Command
    {

        public QuitCommand() : base()
        {
            this.name = "quit";
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add( CommandType.BasicCommand, "Quit Basic Command");
        }

        override
        public bool execute(Player player)
        {
            bool answer = true;
            if (this.hasSecondWord())
            {
                player.outputMessage("\nI cannot quit " + this.secondWord);
                answer = false;
            }
            return answer;
        }
    }
}
