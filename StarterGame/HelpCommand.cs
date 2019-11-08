using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class HelpCommand : Command
    {
        CommandWords words;

        public HelpCommand() : this(new CommandWords())
        {
        }

        public HelpCommand(CommandWords commands) : base()
        {
            words = commands;
            this.name = "help";
            this.CommandType = CommandType.BasicCommand;
        }

        override
        public bool execute(Player player)
        {
            if (this.hasSecondWord())
            {
                player.outputMessage("\nI cannot help you with " + this.secondWord);
            }
            else if (player.currentRoom.shortName == "merchant room")
            {
                //player.outputMessage.("\n\n\nYour available commands " + )
            }
            else 
            {
                player.outputMessage("\n\n\nYour available commands are " + words.description());
            }

            return false;
        }
    }
}
