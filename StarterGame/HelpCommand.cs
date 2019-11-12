﻿using System.Collections;
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
            this.CommandTypes = new Dictionary<CommandType,string>();
            CommandTypes.Add( CommandType.BasicCommand, "Help Basic Command");
            CommandTypes.Add(CommandType.BattleCommand,"Help Battle Command");
            CommandTypes.Add(CommandType.MerchantCommand, "Help Merchant Command");
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
                player.outputMessage("\n\n\nYour available commands: " + words.description(CommandType.MerchantCommand));
            }
            //Player returns true here because he must remain in the battle
            else if (player.InBattle)
            {
                player.outputMessage("\n\n\nYour available commands: " + words.description(CommandType.BattleCommand));
                return true;
            }
            else 
            {
                player.outputMessage("\n\n\nYour available commands are: " + words.description(CommandType.BasicCommand));
            }
            return false;
        }
    }
}
